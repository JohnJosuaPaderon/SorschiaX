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
    internal sealed class GetUserPermissionList : SqlProcessBase, IGetUserPermissionList
    {
        public GetUserPermissionList(
            IConnectionStringProvider connectionStringProvider,
            GetUserPermissionListCommandProvider getUserPermissionListCommandProvider,
            GetUserPermissionListFieldProvider getUserPermissionListFieldProvider) : base(connectionStringProvider.GetDefault())
        {
            _getUserPermissionListCommandProvider = getUserPermissionListCommandProvider;
            _getUserPermissionListFieldProvider = getUserPermissionListFieldProvider;
        }

        private readonly GetUserPermissionListCommandProvider _getUserPermissionListCommandProvider;
        private readonly GetUserPermissionListFieldProvider _getUserPermissionListFieldProvider;

        public GetUserPermissionListModel Model { get; set; }

        private void ReadUserPermission(SqlDataReader reader, GetUserPermissionListResult result) =>
            result.UserPermissionList.Add(new SystemUserPermission
            {
                Id = reader.GetInt64(_getUserPermissionListFieldProvider.Id),
                UserId = reader.GetInt32(_getUserPermissionListFieldProvider.UserId),
                PermissionId = reader.GetInt32(_getUserPermissionListFieldProvider.PermissionId),
                IsApproved = reader.GetBoolean(_getUserPermissionListFieldProvider.IsApproved)
            });

        private void ReadTotalCount(SqlDataReader reader, GetUserPermissionListResult result) =>
            result.TotalCount = reader.GetInt32(_getUserPermissionListFieldProvider.TotalCount);

        private async Task ExecuteGetUserPermissionListAsync(GetUserPermissionListModel model, GetUserPermissionListResult result, SqlConnection connection, CancellationToken cancellationToken)
        {
            using var command = _getUserPermissionListCommandProvider.Get(model, connection);
            using var reader = await command.ExecuteReaderAsync(cancellationToken);

            if (reader.HasRows)
            {
                while (await reader.ReadAsync(cancellationToken))
                    ReadUserPermission(reader, result);

                if (await reader.NextResultAsync(cancellationToken) && await reader.ReadAsync(cancellationToken))
                    ReadTotalCount(reader, result);
            }
        }

        public async Task<GetUserPermissionListResult> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = Model;
                var result = new GetUserPermissionListResult
                {
                    Skip = model.Skip,
                    Take = model.Take
                };
                using var connection = await OpenConnectionAsync(cancellationToken);
                await ExecuteGetUserPermissionListAsync(model, result, connection, cancellationToken);
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
