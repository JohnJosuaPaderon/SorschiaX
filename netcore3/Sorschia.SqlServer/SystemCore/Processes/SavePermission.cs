using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Queries;
using Sorschia.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class SavePermission : ProcessBase, ISavePermission
    {
        private readonly SavePermissionQuery _query;
        private readonly SaveUserPermissionQuery _saveUserPermissionQuery;
        private readonly DeleteUserPermissionQuery _deleteUserPermissionQuery;

        public SavePermissionModel Model { get; set; }

        public SavePermission(IConnectionStringProvider connectionStringProvider,
            SavePermissionQuery query,
            SaveUserPermissionQuery saveUserPermissionQuery, 
            DeleteUserPermissionQuery deleteUserPermissionQuery) : base(connectionStringProvider)
        {
            _query = query;
            _saveUserPermissionQuery = saveUserPermissionQuery;
            _deleteUserPermissionQuery = deleteUserPermissionQuery;
        }

        public async Task<SavePermissionResult> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = ObjectCopy.Copy(Model);
                var result = new SavePermissionResult();
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

        private async Task SaveAsync(Permission permission, SavePermissionResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            var _permission = await _query.ExecuteAsync(permission, connection, transaction, cancellationToken);

            if (_permission is null)
                throw SorschiaException.VariableIsNull<Permission>(nameof(_permission));

            result.Permission = _permission;
        }

        private async Task SaveUserPermissionsAsync(IList<UserPermission> userPermissions, int permissionId, SavePermissionResultBase result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
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

        private async Task DeleteUserPermissionsAsync(IList<DeleteUserPermissionModel> models, SavePermissionResultBase result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
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
