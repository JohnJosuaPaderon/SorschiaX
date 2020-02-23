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
    internal sealed class GetApplicationList : SQLProcessBase, IGetApplicationList
    {
        public GetApplicationList(
            IConnectionStringProvider connectionStringProvider,
            GetApplicationListCommandProvider getApplicationListCommandProvider,
            GetApplicationListFieldProvider getApplicationListFieldProvider) : base(connectionStringProvider.GetDefault())
        {
            _getApplicationListCommandProvider = getApplicationListCommandProvider;
            _getApplicationListFieldProvider = getApplicationListFieldProvider;
        }

        private readonly GetApplicationListCommandProvider _getApplicationListCommandProvider;
        private readonly GetApplicationListFieldProvider _getApplicationListFieldProvider;

        public GetApplicationListModel Model { get; set; }

        private void ReadApplication(SqlDataReader reader, GetApplicationListResult result) =>
            result.ApplicationList.Add(new SystemApplication
            {
                Id = reader.GetInt32(_getApplicationListFieldProvider.Id),
                Name = reader.GetString(_getApplicationListFieldProvider.Name),
                PlatformId = reader.GetNullableInt32(_getApplicationListFieldProvider.PlatformId)
            });

        private void ReadTotalCount(SqlDataReader reader, GetApplicationListResult result) =>
            result.TotalCount = reader.GetInt32(_getApplicationListFieldProvider.TotalCount);

        private async Task ExecuteGetApplicationListAsync(GetApplicationListModel model, GetApplicationListResult result, SqlConnection connection, CancellationToken cancellationToken)
        {
            using var command = _getApplicationListCommandProvider.Get(model, connection);
            using var reader = await command.ExecuteReaderAsync(cancellationToken);

            if (reader.HasRows)
            {
                while (await reader.ReadAsync(cancellationToken))
                    ReadApplication(reader, result);

                if (await reader.NextResultAsync(cancellationToken) && await reader.ReadAsync(cancellationToken))
                    ReadTotalCount(reader, result);
            }
        }

        public async Task<GetApplicationListResult> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = Model;
                var result = new GetApplicationListResult
                {
                    Skip = model.Skip,
                    Take = model.Take
                };
                using var connection = await OpenConnectionAsync(cancellationToken);
                await ExecuteGetApplicationListAsync(model, result, connection, cancellationToken);
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
