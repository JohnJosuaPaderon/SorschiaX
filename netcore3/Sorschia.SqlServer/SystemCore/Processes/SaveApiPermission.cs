using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Queries;
using Sorschia.Utilities;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class SaveApiPermission : SavePermissionBase, ISaveApiPermission
    {
        private readonly SaveApiPermissionQuery _query;

        public SaveApiPermissionModel Model { get; set; }

        public SaveApiPermission(IConnectionStringProvider connectionStringProvider,
            SaveUserPermissionQuery saveUserPermissionQuery,
            DeleteUserPermissionQuery deleteUserPermissionQuery,
            SaveApiPermissionQuery query) : base(connectionStringProvider, saveUserPermissionQuery, deleteUserPermissionQuery)
        {
            _query = query;
        }

        public async Task<SaveApiPermissionResult> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = ObjectCopy.Copy(Model);
                var result = new SaveApiPermissionResult();
                using var connection = await OpenConnectionAsync(cancellationToken);
                using var transaction = connection.BeginTransaction();
                await SaveAsync(model.Permission, result, connection, transaction, cancellationToken);
                await SaveUserPermissionsAsync(model.UserPermissions, result.Permission.Id, result, connection, transaction, cancellationToken);
                await DeleteUserPermissionsAsync(model.DeletedUserPermissions, result, connection, transaction, cancellationToken);
                transaction.Commit();
                return result;
            }
            catch (Exception ex)
            {
                ThrowError(ex);
                return default;
            }
        }

        private async Task SaveAsync(ApiPermission permission, SaveApiPermissionResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            var _permission = await _query.ExecuteAsync(permission, connection, transaction, cancellationToken);

            if (_permission is null)
                throw SorschiaException.VariableIsNull<ApiPermission>(nameof(_permission));

            result.Permission = _permission;
        }
    }
}
