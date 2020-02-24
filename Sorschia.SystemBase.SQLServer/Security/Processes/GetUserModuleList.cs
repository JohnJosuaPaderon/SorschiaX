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
    internal sealed class GetUserModuleList : SQLProcessBase, IGetUserModuleList
    {
        public GetUserModuleList(
            IConnectionStringProvider connectionStringProvider,
            GetUserModuleListCommandProvider getUserModuleListCommandProvider,
            GetUserModuleListFieldProvider getUserModuleListFieldProvider) : base(connectionStringProvider.GetDefault())
        {
            _getUserModuleListCommandProvider = getUserModuleListCommandProvider;
            _getUserModuleListFieldProvider = getUserModuleListFieldProvider;
        }

        private readonly GetUserModuleListCommandProvider _getUserModuleListCommandProvider;
        private readonly GetUserModuleListFieldProvider _getUserModuleListFieldProvider;

        public GetUserModuleListModel Model { get; set; }

        private void ReadUserModule(SqlDataReader reader, GetUserModuleListResult result) =>
            result.UserModuleList.Add(new SystemUserModule
            {
                Id = reader.GetInt64(_getUserModuleListFieldProvider.Id),
                UserId = reader.GetInt32(_getUserModuleListFieldProvider.UserId),
                ModuleId = reader.GetInt32(_getUserModuleListFieldProvider.ModuleId),
                IsApproved = reader.GetBoolean(_getUserModuleListFieldProvider.IsApproved)
            });

        private void ReadTotalCount(SqlDataReader reader, GetUserModuleListResult result) =>
            result.TotalCount = reader.GetInt32(_getUserModuleListFieldProvider.TotalCount);

        private async Task ExecuteGetUserModuleListAsync(GetUserModuleListModel model, GetUserModuleListResult result, SqlConnection connection, CancellationToken cancellationToken)
        {
            using var command = _getUserModuleListCommandProvider.Get(model, connection);
            using var reader = await command.ExecuteReaderAsync(cancellationToken);

            if (reader.HasRows)
            {
                while (await reader.ReadAsync(cancellationToken))
                    ReadUserModule(reader, result);

                if (await reader.NextResultAsync(cancellationToken) && await reader.ReadAsync(cancellationToken))
                    ReadTotalCount(reader, result);
            }
        }

        public async Task<GetUserModuleListResult> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = Model;
                var result = new GetUserModuleListResult
                {
                    Skip = model.Skip,
                    Take = model.Take
                };
                using var connection = await OpenConnectionAsync(cancellationToken);
                await ExecuteGetUserModuleListAsync(model, result, connection, cancellationToken);
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
