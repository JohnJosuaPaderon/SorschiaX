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
    internal sealed class GetUserApplicationList : SQLProcessBase, IGetUserApplicationList
    {
        public GetUserApplicationList(
            IConnectionStringProvider connectionStringProvider,
            GetUserApplicationListCommandProvider getUserApplicationListCommandProvider,
            GetUserApplicationListFieldProvider getUserApplicationListFieldProvider) : base(connectionStringProvider.GetDefault())
        {
            _getUserApplicationListCommandProvider = getUserApplicationListCommandProvider;
            _getUserApplicationListFieldProvider = getUserApplicationListFieldProvider;
        }

        private readonly GetUserApplicationListCommandProvider _getUserApplicationListCommandProvider;
        private readonly GetUserApplicationListFieldProvider _getUserApplicationListFieldProvider;

        public GetUserApplicationListModel Model { get; set; }

        private void ReadUserApplication(SqlDataReader reader, GetUserApplicationListResult result) =>
            result.UserApplicationList.Add(new SystemUserApplication
            {
                Id = reader.GetInt64(_getUserApplicationListFieldProvider.Id),
                UserId = reader.GetInt32(_getUserApplicationListFieldProvider.UserId),
                ApplicationId = reader.GetInt32(_getUserApplicationListFieldProvider.ApplicationId),
                IsApproved = reader.GetBoolean(_getUserApplicationListFieldProvider.IsApproved)
            });

        private void ReadTotalCount(SqlDataReader reader, GetUserApplicationListResult result) =>
            result.TotalCount = reader.GetInt32(_getUserApplicationListFieldProvider.TotalCount);

        private async Task ExecuteGetUserApplicationListAsync(GetUserApplicationListModel model, GetUserApplicationListResult result, SqlConnection connection, CancellationToken cancellationToken)
        {
            using var command = _getUserApplicationListCommandProvider.Get(model, connection);
            using var reader = await command.ExecuteReaderAsync(cancellationToken);

            if (reader.HasRows)
            {
                while (await reader.ReadAsync(cancellationToken))
                    ReadUserApplication(reader, result);

                if (await reader.NextResultAsync(cancellationToken) && await reader.ReadAsync(cancellationToken))
                    ReadTotalCount(reader, result);
            }
        }

        public async Task<GetUserApplicationListResult> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = Model;
                var result = new GetUserApplicationListResult
                {
                    Skip = model.Skip,
                    Take = model.Take
                };
                using var connection = await OpenConnectionAsync(cancellationToken);
                await ExecuteGetUserApplicationListAsync(model, result, connection, cancellationToken);
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
