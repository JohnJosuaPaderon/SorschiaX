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
    internal sealed class SaveUser : ProcessBase, ISaveUser
    {
        private readonly SaveUserQuery _query;
        private readonly SaveUserApplicationQuery _saveUserApplicationQuery;
        private readonly SaveUserModuleQuery _saveUserModuleQuery;
        private readonly SaveUserPermissionQuery _saveUserPermissionQuery;
        private readonly DeleteUserApplicationQuery _deleteUserApplicationQuery;
        private readonly DeleteUserModuleQuery _deleteUserModuleQuery;
        private readonly DeleteUserPermissionQuery _deleteUserPermissionQuery;

        public SaveUserModel Model { get; set; }
        
        public SaveUser(IConnectionStringProvider connectionStringProvider,
            SaveUserQuery query,
            SaveUserApplicationQuery saveUserApplicationQuery,
            SaveUserModuleQuery saveUserModuleQuery,
            SaveUserPermissionQuery saveUserPermissionQuery,
            DeleteUserApplicationQuery deleteUserApplicationQuery,
            DeleteUserModuleQuery deleteUserModuleQuery,
            DeleteUserPermissionQuery deleteUserPermissionQuery) : base(connectionStringProvider)
        {
            _query = query;
            _saveUserApplicationQuery = saveUserApplicationQuery;
            _saveUserModuleQuery = saveUserModuleQuery;
            _saveUserPermissionQuery = saveUserPermissionQuery;
            _deleteUserApplicationQuery = deleteUserApplicationQuery;
            _deleteUserModuleQuery = deleteUserModuleQuery;
            _deleteUserPermissionQuery = deleteUserPermissionQuery;
        }

        public async Task<SaveUserResult> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = ObjectCopy.Copy(Model);
                var result = new SaveUserResult();
                using var connection = await OpenConnectionAsync(cancellationToken);
                using var transaction = connection.BeginTransaction();
                await SaveAsync(model.User, result, connection, transaction, cancellationToken);
                await SaveUserApplicationsAsync(model.UserApplications, result, connection, transaction, cancellationToken);
                await SaveUserModulesAsync(model.UserModules, result, connection, transaction, cancellationToken);
                await SaveUserPermissionsAsync(model.UserPermissions, result, connection, transaction, cancellationToken);
                await DeleteUserApplicationsAsync(model.DeletedUserApplications, result, connection, transaction, cancellationToken);
                await DeleteUserModulesAsync(model.DeletedUserModules, result, connection, transaction, cancellationToken);
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

        private async Task SaveAsync(SaveUserModel.UserObj user, SaveUserResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            var _user = await _query.ExecuteAsync(user, connection, transaction, cancellationToken);

            if (_user is null)
                throw SorschiaException.VariableIsNull<User>(nameof(_user));

            result.User = user;
        }

        private async Task SaveUserApplicationsAsync(IList<UserApplication> userApplications, SaveUserResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (userApplications != null && userApplications.Count > 0)
                foreach (var userApplication in userApplications)
                {
                    userApplication.UserId = result.User.Id;
                    await SaveUserApplicationAsync(userApplication, result, connection, transaction, cancellationToken);
                }
        }

        private async Task SaveUserApplicationAsync(UserApplication userApplication, SaveUserResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            var _userApplication = await _saveUserApplicationQuery.ExecuteAsync(userApplication, connection, transaction, cancellationToken);

            if (_userApplication is null)
                throw SorschiaException.VariableIsNull<UserApplication>(nameof(_userApplication));

            result.UserApplications.Add(_userApplication);
        }

        private async Task SaveUserModulesAsync(IList<UserModule> userModules, SaveUserResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (userModules != null && userModules.Count > 0)
                foreach (var userModule in userModules)
                {
                    userModule.UserId = result.User.Id;
                    await SaveUserModuleAsync(userModule, result, connection, transaction, cancellationToken);
                }
        }

        private async Task SaveUserModuleAsync(UserModule userModule, SaveUserResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            var _userModule = await _saveUserModuleQuery.ExecuteAsync(userModule, connection, transaction, cancellationToken);

            if (_userModule is null)
                throw SorschiaException.VariableIsNull<UserModule>(nameof(_userModule));

            result.UserModules.Add(_userModule);
        }

        private async Task SaveUserPermissionsAsync(IList<UserPermission> userPermissions, SaveUserResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (userPermissions != null && userPermissions.Count > 0)
                foreach (var userPermission in userPermissions)
                {
                    userPermission.UserId = result.User.Id;
                    await SaveUserPermissionAsync(userPermission, result, connection, transaction, cancellationToken);
                }
        }

        private async Task SaveUserPermissionAsync(UserPermission userPermission, SaveUserResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            var _userPermission = await _saveUserPermissionQuery.ExecuteAsync(userPermission, connection, transaction, cancellationToken);

            if (_userPermission is null)
                throw SorschiaException.VariableIsNull<UserPermission>(nameof(_userPermission));

            result.UserPermissions.Add(_userPermission);
        }

        public async Task DeleteUserApplicationsAsync(IList<DeleteUserApplicationModel> models, SaveUserResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (models != null && models.Count > 0)
                foreach (var model in models)
                    await DeleteUserApplicationAsync(model, result, connection, transaction, cancellationToken);
        }

        private async Task DeleteUserApplicationAsync(DeleteUserApplicationModel model, SaveUserResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (await _deleteUserApplicationQuery.ExecuteAsync(model, connection, transaction, cancellationToken))
                result.DeletedUserApplicationIds.Add(model.Id);
        }

        public async Task DeleteUserModulesAsync(IList<DeleteUserModuleModel> models, SaveUserResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (models != null && models.Count > 0)
                foreach (var model in models)
                    await DeleteUserModuleAsync(model, result, connection, transaction, cancellationToken);
        }

        private async Task DeleteUserModuleAsync(DeleteUserModuleModel model, SaveUserResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (await _deleteUserModuleQuery.ExecuteAsync(model, connection, transaction, cancellationToken))
                result.DeletedUserModuleIds.Add(model.Id);
        }

        public async Task DeleteUserPermissionsAsync(IList<DeleteUserPermissionModel> models, SaveUserResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (models != null && models.Count > 0)
                foreach (var model in models)
                    await DeleteUserPermissionAsync(model, result, connection, transaction, cancellationToken);
        }

        private async Task DeleteUserPermissionAsync(DeleteUserPermissionModel model, SaveUserResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (await _deleteUserPermissionQuery.ExecuteAsync(model, connection, transaction, cancellationToken))
                result.DeletedUserPermissionIds.Add(model.Id);
        }
    }
}
