using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Queries;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal abstract class SavePermissionBase : ProcessBase
    {
        private readonly SaveUserPermissionQuery _saveUserPermissionQuery;
        private readonly DeleteUserPermissionQuery _deleteUserPermissionQuery;

        protected SavePermissionBase(IConnectionStringProvider connectionStringProvider,
            SaveUserPermissionQuery saveUserPermissionQuery,
            DeleteUserPermissionQuery deleteUserPermissionQuery) : base(connectionStringProvider)
        {
            _saveUserPermissionQuery = saveUserPermissionQuery;
            _deleteUserPermissionQuery = deleteUserPermissionQuery;
        }

        protected async Task SaveUserPermissionsAsync(IList<UserPermission> userPermissions, int permissionId, SavePermissionResultBase result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (userPermissions != null && userPermissions.Count > 0)
                foreach (var userPermission in userPermissions)
                {
                    userPermission.PermissionId = permissionId;
                    await SaveUserPermissionAsync(userPermission, result, connection, transaction, cancellationToken);
                }
        }

        private async Task SaveUserPermissionAsync(UserPermission userPermission, SavePermissionResultBase result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            var _userPermission = await _saveUserPermissionQuery.ExecuteAsync(userPermission, connection, transaction, cancellationToken);

            if (_userPermission is null)
                throw SorschiaException.VariableIsNull<UserPermission>(nameof(_userPermission));

            result.UserPermissions.Add(_userPermission);
        }

        protected async Task DeleteUserPermissionsAsync(IList<DeleteUserPermissionModel> models, SavePermissionResultBase result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (models != null && models.Count > 0)
                foreach (var model in models)
                    await DeleteUserPermissionAsync(model, result, connection, transaction, cancellationToken);
        }

        private async Task DeleteUserPermissionAsync(DeleteUserPermissionModel model, SavePermissionResultBase result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (await _deleteUserPermissionQuery.ExecuteAsync(model, connection, transaction, cancellationToken))
                result.DeletedUserPermissionIds.Add(model.Id);
        }
    }
}
