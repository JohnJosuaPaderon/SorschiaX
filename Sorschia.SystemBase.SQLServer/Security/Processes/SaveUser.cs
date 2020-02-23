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
    internal sealed class SaveUser : SQLProcessBase, ISaveUser
    {
        public SaveUser(
            IConnectionStringProvider connectionStringProvider,
            SaveUserCommandProvider saveUserCommandProvider,
            SaveUserParameterProvider saveUserParameterProvider,
            SaveUserApplicationCommandProvider saveUserApplicationCommandProvider,
            SaveUserApplicationParameterProvider saveUserApplicationParameterProvider,
            DeleteUserApplicationCommandProvider deleteUserApplicationCommandProvider,
            SaveUserModuleCommandProvider saveUserModuleCommandProvider,
            SaveUserModuleParameterProvider saveUserModuleParameterProvider,
            DeleteUserModuleCommandProvider deleteUserModuleCommandProvider,
            SaveUserPermissionCommandProvider saveUserPermissionCommandProvider,
            SaveUserPermissionParameterProvider saveUserPermissionParameterProvider,
            DeleteUserPermissionCommandProvider deleteUserPermissionCommandProvider) : base(connectionStringProvider.GetDefault())
        {
            _saveUserCommandProvider = saveUserCommandProvider;
            _saveUserParameterProvider = saveUserParameterProvider;
            _saveUserApplicationCommandProvider = saveUserApplicationCommandProvider;
            _saveUserApplicationParameterProvider = saveUserApplicationParameterProvider;
            _deleteUserApplicationCommandProvider = deleteUserApplicationCommandProvider;
            _saveUserModuleCommandProvider = saveUserModuleCommandProvider;
            _saveUserModuleParameterProvider = saveUserModuleParameterProvider;
            _deleteUserModuleCommandProvider = deleteUserModuleCommandProvider;
            _saveUserPermissionCommandProvider = saveUserPermissionCommandProvider;
            _saveUserPermissionParameterProvider = saveUserPermissionParameterProvider;
            _deleteUserPermissionCommandProvider = deleteUserPermissionCommandProvider;
        }

        private readonly SaveUserCommandProvider _saveUserCommandProvider;
        private readonly SaveUserParameterProvider _saveUserParameterProvider;
        private readonly SaveUserApplicationCommandProvider _saveUserApplicationCommandProvider;
        private readonly SaveUserApplicationParameterProvider _saveUserApplicationParameterProvider;
        private readonly DeleteUserApplicationCommandProvider _deleteUserApplicationCommandProvider;
        private readonly SaveUserModuleCommandProvider _saveUserModuleCommandProvider;
        private readonly SaveUserModuleParameterProvider _saveUserModuleParameterProvider;
        private readonly DeleteUserModuleCommandProvider _deleteUserModuleCommandProvider;
        private readonly SaveUserPermissionCommandProvider _saveUserPermissionCommandProvider;
        private readonly SaveUserPermissionParameterProvider _saveUserPermissionParameterProvider;
        private readonly DeleteUserPermissionCommandProvider _deleteUserPermissionCommandProvider;

        public SaveUserModel Model { get; set; }

        #region SaveUser
        private async Task ExecuteSaveUserAsync(SystemUser user, SaveUserResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            using var command = _saveUserCommandProvider.Get(user, connection, transaction);

            if (await command.ExecuteNonQueryAsync(cancellationToken) == 1)
            {
                user.Id = command.Parameters.GetInt32(_saveUserParameterProvider.Id);
                result.User = user;
            }
        }
        #endregion

        #region SaveUserApplication
        private async Task ExecuteSaveUserApplicationAsync(SystemUserApplication userApplication, SaveUserResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            using var command = _saveUserApplicationCommandProvider.Get(userApplication, connection, transaction);

            if (await command.ExecuteNonQueryAsync(cancellationToken) == 1)
            {
                userApplication.Id = command.Parameters.GetInt64(_saveUserApplicationParameterProvider.Id);
                result.UserApplicationList.Add(userApplication);
            }
        }

        private async Task ExecuteSaveUserApplicationListAsync(IList<SystemUserApplication> userApplicationList, SaveUserResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (userApplicationList != null && userApplicationList.Any())
                foreach (var userApplication in userApplicationList)
                {
                    userApplication.UserId = result.User.Id;
                    await ExecuteSaveUserApplicationAsync(userApplication, result, connection, transaction, cancellationToken);
                }
        }
        #endregion

        #region DeleteUserApplication
        private async Task ExecuteDeleteUserApplicationAsync(long id, SaveUserResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            using var command = _deleteUserApplicationCommandProvider.Get(id, connection, transaction);

            if (await command.ExecuteNonQueryAsync(cancellationToken) == 1)
                result.DeletedUserApplicationIdList.Add(id);
        }

        private async Task ExecuteDeleteUserApplicationListAsync(IList<long> idList, SaveUserResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (idList != null && idList.Any())
                foreach (var id in idList)
                    await ExecuteDeleteUserApplicationAsync(id, result, connection, transaction, cancellationToken);
        }
        #endregion

        #region SaveUserModule
        private async Task ExecuteSaveUserModuleAsync(SystemUserModule userModule, SaveUserResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            using var command = _saveUserModuleCommandProvider.Get(userModule, connection, transaction);

            if (await command.ExecuteNonQueryAsync(cancellationToken) == 1)
            {
                userModule.Id = command.Parameters.GetInt64(_saveUserModuleParameterProvider.Id);
                result.UserModuleList.Add(userModule);
            }
        }

        private async Task ExecuteSaveUserModuleListAsync(IList<SystemUserModule> userModuleList, SaveUserResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (userModuleList != null && userModuleList.Any())
            {
                foreach (var userModule in userModuleList)
                {
                    userModule.UserId = result.User.Id;
                    await ExecuteSaveUserModuleAsync(userModule, result, connection, transaction, cancellationToken);
                }
            }
        }
        #endregion

        #region DeleteUserModule
        private async Task ExecuteDeleteUserModuleAsync(long id, SaveUserResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            using var command = _deleteUserModuleCommandProvider.Get(id, connection, transaction);

            if (await command.ExecuteNonQueryAsync(cancellationToken) == 1)
                result.DeletedUserModuleIdList.Add(id);
        }

        private async Task ExecuteDeleteUserModuleListAsync(IList<long> idList, SaveUserResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (idList != null && idList.Any())
            {
                foreach (var id in idList)
                    await ExecuteDeleteUserModuleAsync(id, result, connection, transaction, cancellationToken);
            }
        }
        #endregion

        #region SaveUserPermission
        private async Task ExecuteSaveUserPermissionAsync(SystemUserPermission userPermission, SaveUserResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            using var command = _saveUserPermissionCommandProvider.Get(userPermission, connection, transaction);

            if (await command.ExecuteNonQueryAsync(cancellationToken) == 1)
            {
                userPermission.Id = command.Parameters.GetInt64(_saveUserPermissionParameterProvider.Id);
                result.UserPermissionList.Add(userPermission);
            }
        }

        private async Task ExecuteSaveUserPermissionListAsync(IList<SystemUserPermission> userPermissionList, SaveUserResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (userPermissionList != null && userPermissionList.Any())
                foreach (var userPermission in userPermissionList)
                {
                    userPermission.UserId = result.User.Id;
                    await ExecuteSaveUserPermissionAsync(userPermission, result, connection, transaction, cancellationToken);
                }
        }
        #endregion

        #region DeleteUserPermission
        private async Task ExecuteDeleteUserPermissionAsync(long id, SaveUserResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            using var command = _deleteUserPermissionCommandProvider.Get(id, connection, transaction);

            if (await command.ExecuteNonQueryAsync(cancellationToken) == 1)
                result.DeletedUserPermissionIdList.Add(id);
        }

        private async Task ExecuteDeleteUserPermissionListAsync(IList<long> idList, SaveUserResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (idList != null && idList.Any())
                foreach (var id in idList)
                    await ExecuteDeleteUserPermissionAsync(id, result, connection, transaction, cancellationToken);
        }
        #endregion

        public async Task<SaveUserResult> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = Model;
                var result = new SaveUserResult();
                using var connection = await OpenConnectionAsync(cancellationToken);
                using var transaction = connection.BeginTransaction();
                await ExecuteSaveUserAsync(model.User, result, connection, transaction, cancellationToken);
                await ExecuteSaveUserApplicationListAsync(model.UserApplicationList, result, connection, transaction, cancellationToken);
                await ExecuteDeleteUserApplicationListAsync(model.DeletedUserApplicationIdList, result, connection, transaction, cancellationToken);
                await ExecuteSaveUserModuleListAsync(model.UserModuleList, result, connection, transaction, cancellationToken);
                await ExecuteDeleteUserModuleListAsync(model.DeletedUserModuleIdList, result, connection, transaction, cancellationToken);
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
