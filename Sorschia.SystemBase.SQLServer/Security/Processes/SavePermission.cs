using Sorschia.Data;
using Sorschia.SystemBase.Data;
using Sorschia.SystemBase.Security.CommandProviders;
using Sorschia.SystemBase.Security.Entities;
using Sorschia.SystemBase.Security.ParameterProviders;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemBase.Security.Processes
{
    internal sealed class SavePermission : SQLProcessBase, ISavePermission
    {
        public SavePermission(
            IConnectionStringProvider connectionStringProvider,
            SavePermissionCommandProvider savePermissionCommandProvider,
            SavePermissionParameterProvider savePermissionParameterProvider,
            SaveUserPermissionCommandProvider saveUserPermissionCommandProvider,
            SaveUserPermissionParameterProvider saveUserPermissionParameterProvider,
            DeleteUserPermissionCommandProvider deleteUserPermissionCommandProvider) : base(connectionStringProvider.GetDefault())
        {
            _savePermissionCommandProvider = savePermissionCommandProvider;
            _savePermissionParameterProvider = savePermissionParameterProvider;
            _saveUserPermissionCommandProvider = saveUserPermissionCommandProvider;
            _saveUserPermissionParameterProvider = saveUserPermissionParameterProvider;
            _deleteUserPermissionCommandProvider = deleteUserPermissionCommandProvider;
        }

        private readonly SavePermissionCommandProvider _savePermissionCommandProvider;
        private readonly SavePermissionParameterProvider _savePermissionParameterProvider;
        private readonly SaveUserPermissionCommandProvider _saveUserPermissionCommandProvider;
        private readonly SaveUserPermissionParameterProvider _saveUserPermissionParameterProvider;
        private readonly DeleteUserPermissionCommandProvider _deleteUserPermissionCommandProvider;

        public SavePermissionModel Model { get; set; }

        #region SavePermission
        private async Task ExecuteSavePermissionAsync(SystemPermission permission, SavePermissionResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            using var command = _savePermissionCommandProvider.Get(permission, connection, transaction);

            if (await command.ExecuteNonQueryAsync(cancellationToken) == 1)
            {
                permission.Id = command.Parameters.GetInt32(_savePermissionParameterProvider.Id);
                result.Permission = permission;
            }
        }
        #endregion

        #region SaveUserPermission
        private async Task ExecuteSaveUserPermissionAsync(SystemUserPermission userPermission, SavePermissionResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            using var command = _saveUserPermissionCommandProvider.Get(userPermission, connection, transaction);

            if (await command.ExecuteNonQueryAsync(cancellationToken) == 1)
            {
                userPermission.Id = command.Parameters.GetInt64(_saveUserPermissionParameterProvider.Id);
                result.UserPermissionList.Add(userPermission);
            }
        }

        private async Task ExecuteSaveUserPermissionListAsync(IList<SystemUserPermission> userPermissionList, SavePermissionResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (userPermissionList != null && userPermissionList.Any())
                foreach (var userPermission in userPermissionList)
                {
                    userPermission.PermissionId = result.Permission.Id;
                    await ExecuteSaveUserPermissionAsync(userPermission, result, connection, transaction, cancellationToken);
                }
        }
        #endregion

        #region DeleteUserPermission
        private async Task ExecuteDeleteUserPermissionAsync(long id, SavePermissionResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            using var command = _deleteUserPermissionCommandProvider.Get(id, connection, transaction);

            if (await command.ExecuteNonQueryAsync(cancellationToken) == 1)
                result.DeletedUserPermissionIdList.Add(id);
        }

        private async Task ExecuteDeleteUserPermissionListAsync(IList<long> idList, SavePermissionResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (idList != null && idList.Any())
                foreach (var id in idList)
                    await ExecuteDeleteUserPermissionAsync(id, result, connection, transaction, cancellationToken); 
        }
        #endregion

        public async Task<SavePermissionResult> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = Model;
                var result = new SavePermissionResult();
                using var connection = await OpenConnectionAsync(cancellationToken);
                using var transaction = connection.BeginTransaction();
                await ExecuteSavePermissionAsync(model.Permission, result, connection, transaction, cancellationToken);
                await ExecuteSaveUserPermissionListAsync(model.UserPermissionList, result, connection, transaction, cancellationToken);
                await ExecuteDeleteUserPermissionListAsync(model.DeletedUserPermissionIdList, result, connection, transaction, cancellationToken);
                transaction.Commit();
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
