using Sorschia.Data;
using Sorschia.SystemBase.Data;
using Sorschia.SystemBase.Security.CommandProviders;
using Sorschia.SystemBase.Security.Entities;
using Sorschia.SystemBase.Security.FieldProviders;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemBase.Security.Processes
{
    internal sealed class GetApplicationPlatformList : SQLProcessBase, IGetApplicationPlatformList
    {
        public GetApplicationPlatformList(
            IConnectionStringProvider connectionStringProvider,
            GetApplicationPlatformListCommandProvider getApplicationPlatformListCommandProvider,
            GetApplicationPlatformListFieldProvider getApplicationPlatformListFieldProvider) : base(connectionStringProvider.GetDefault())
        {
            _getApplicationPlatformListCommandProvider = getApplicationPlatformListCommandProvider;
            _getApplicationPlatformListFieldProvider = getApplicationPlatformListFieldProvider;
        }

        private readonly GetApplicationPlatformListCommandProvider _getApplicationPlatformListCommandProvider;
        private readonly GetApplicationPlatformListFieldProvider _getApplicationPlatformListFieldProvider;

        public GetApplicationPlatformListModel Model { get; set; }

        private void ReadApplicationPlatform(SqlDataReader reader, GetApplicationPlatformListResult result) =>
            result.ApplicationPlatformList.Add(new SystemApplicationPlatform
            {
                Id = reader.GetInt32(_getApplicationPlatformListFieldProvider.Id),
                Name = reader.GetString(_getApplicationPlatformListFieldProvider.Name)
            });

        private void ReadTotalCount(SqlDataReader reader, GetApplicationPlatformListResult result) =>
            result.TotalCount = reader.GetInt32(_getApplicationPlatformListFieldProvider.TotalCount);

        private async Task ExecuteGetApplicationPlatformListAsync(GetApplicationPlatformListModel model, GetApplicationPlatformListResult result, SqlConnection connection, CancellationToken cancellationToken)
        {
            using var command = _getApplicationPlatformListCommandProvider.Get(model, connection);
            using var reader = await command.ExecuteReaderAsync(cancellationToken);

            if (reader.HasRows)
            {
                while (await reader.ReadAsync(cancellationToken))
                    ReadApplicationPlatform(reader, result);

                if (await reader.NextResultAsync(cancellationToken) && await reader.ReadAsync(cancellationToken))
                    ReadTotalCount(reader, result);
            }
        }

        public async Task<GetApplicationPlatformListResult> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = Model;
                var result = new GetApplicationPlatformListResult
                {
                    Skip = model.Skip,
                    Take = model.Take
                };
                using var connection = await OpenConnectionAsync(cancellationToken);
                await ExecuteGetApplicationPlatformListAsync(model, result, connection, cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                ThrowError(ex);
                return default;
            }
        }
    }
}
