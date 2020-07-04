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
    internal sealed class SaveModule : ProcessBase, ISaveModule
    {
        private readonly SaveModuleQuery _query;
        private readonly SaveUserModuleQuery _saveUserModuleQuery;
        private readonly DeleteUserModuleQuery _deleteUserModuleQuery;

        public SaveModuleModel Model { get; set; }

        public SaveModule(IConnectionStringProvider connectionStringProvider,
            SaveModuleQuery query,
            SaveUserModuleQuery saveUserModuleQuery,
            DeleteUserModuleQuery deleteUserModuleQuery) : base(connectionStringProvider)
        {
            _query = query;
            _saveUserModuleQuery = saveUserModuleQuery;
            _deleteUserModuleQuery = deleteUserModuleQuery;
        }

        public async Task<SaveModuleResult> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = ObjectCopy.Copy(Model);
                var result = new SaveModuleResult();
                using var connection = await OpenConnectionAsync(cancellationToken);
                using var transaction = connection.BeginTransaction();
                await SaveAsync(model.Module, result, connection, transaction, cancellationToken);
                await SaveUserModulesAsync(model.UserModules, result, connection, transaction, cancellationToken);
                await DeleteUserModulesAsync(model.DeletedUserModules, result, connection, transaction, cancellationToken);
                transaction.Commit();
                return result;
            }
            catch (Exception ex)
            {
                ThrowError(ex);
                return default;
            }
        }

        private async Task SaveAsync(Module module, SaveModuleResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            var _module = await _query.ExecuteAsync(module, connection, transaction, cancellationToken);

            if (_module is null)
                throw SorschiaException.VariableIsNull<Module>(nameof(_module));

            result.Module = _module;
        }

        private async Task SaveUserModulesAsync(IList<UserModule> userModules, SaveModuleResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (userModules != null && userModules.Count > 0)
                foreach (var userModule in userModules)
                {
                    userModule.ModuleId = result.Module.Id;
                    await SaveUserModuleAsync(userModule, result, connection, transaction, cancellationToken);
                }
        }

        private async Task SaveUserModuleAsync(UserModule userModule, SaveModuleResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            var _userModule = await _saveUserModuleQuery.ExecuteAsync(userModule, connection, transaction, cancellationToken);

            if (_userModule is null)
                throw SorschiaException.VariableIsNull<UserModule>(nameof(_userModule));

            result.UserModules.Add(_userModule);
        }

        public async Task DeleteUserModulesAsync(IList<DeleteUserModuleModel> models, SaveModuleResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (models != null && models.Count > 0)
                foreach (var model in models)
                    await DeleteUserModuleAsync(model, result, connection, transaction, cancellationToken);
        }

        private async Task DeleteUserModuleAsync(DeleteUserModuleModel model, SaveModuleResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (await _deleteUserModuleQuery.ExecuteAsync(model, connection, transaction, cancellationToken))
                result.DeletedUserModuleIds.Add(model.Id);
        }
    }
}
