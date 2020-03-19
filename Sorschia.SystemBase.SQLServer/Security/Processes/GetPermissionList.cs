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
    internal sealed class GetPermissionList : SqlProcessBase, IGetPermissionList
    {
        public GetPermissionList(
            IConnectionStringProvider connectionStringProvider,
            GetPermissionListCommandProvider getPermissionListCommandProvider,
            GetPermissionListFieldProvider getPermissionListFieldProvider) : base(connectionStringProvider.GetDefault())
        {
            _getPermissionListCommandProvider = getPermissionListCommandProvider;
            _getPermissionListFieldProvider = getPermissionListFieldProvider;
        }

        private readonly GetPermissionListCommandProvider _getPermissionListCommandProvider;
        private readonly GetPermissionListFieldProvider _getPermissionListFieldProvider;

        public GetPermissionListModel Model { get; set; }

        private void ReadPermission(SqlDataReader reader, GetPermissionListResult result) =>
            result.PermissionList.Add(new SystemPermission
            {
                Id = reader.GetInt32(_getPermissionListFieldProvider.Id),
                Name = reader.GetString(_getPermissionListFieldProvider.Name),
                Code = reader.GetString(_getPermissionListFieldProvider.Code)
            });

        private void ReadTotalCount(SqlDataReader reader, GetPermissionListResult result) =>
            result.TotalCount = reader.GetInt32(_getPermissionListFieldProvider.TotalCount);

        private async Task ExecuteGetPermissionListAsync(GetPermissionListModel model, GetPermissionListResult result, SqlConnection connection, CancellationToken cancellationToken)
        {
            using var command = _getPermissionListCommandProvider.Get(model, connection);
            using var reader = await command.ExecuteReaderAsync(cancellationToken);

            if (reader.HasRows)
            {
                while (await reader.ReadAsync(cancellationToken))
                    ReadPermission(reader, result);

                if (await reader.NextResultAsync(cancellationToken) && await reader.ReadAsync(cancellationToken))
                    ReadTotalCount(reader, result);
            }
        }

        public async Task<GetPermissionListResult> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = Model;
                var result = new GetPermissionListResult
                {
                    Skip = model.Skip,
                    Take = model.Take
                };
                using var connection = await OpenConnectionAsync(cancellationToken);
                await ExecuteGetPermissionListAsync(model, result, connection, cancellationToken);
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
