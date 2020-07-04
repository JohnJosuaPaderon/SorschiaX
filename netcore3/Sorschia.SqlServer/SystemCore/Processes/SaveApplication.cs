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
    internal sealed class SaveApplication : ProcessBase, ISaveApplication
    {
        private readonly SaveApplicationQuery _query;
        private readonly SaveModuleQuery _saveModuleQuery;
        private readonly SaveUserApplicationQuery _saveUserApplicationQuery;
        private readonly DeleteModuleQuery _deleteModuleQuery;
        private readonly DeleteUserApplicationQuery _deleteUserApplicationQuery;

        public SaveApplicationModel Model { get; set; }

        public SaveApplication(IConnectionStringProvider connectionStringProvider,
            SaveApplicationQuery query,
            SaveModuleQuery saveModuleQuery,
            SaveUserApplicationQuery saveUserApplicationQuery,
            DeleteModuleQuery deleteModuleQuery,
            DeleteUserApplicationQuery deleteUserApplicationQuery) : base(connectionStringProvider)
        {
            _query = query;
            _saveModuleQuery = saveModuleQuery;
            _saveUserApplicationQuery = saveUserApplicationQuery;
            _deleteModuleQuery = deleteModuleQuery;
            _deleteUserApplicationQuery = deleteUserApplicationQuery;
        }

        public async Task<SaveApplicationResult> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = ObjectCopy.Copy(Model);
                var result = new SaveApplicationResult();
                using var connection = await OpenConnectionAsync(cancellationToken);
                using var transaction = connection.BeginTransaction();
                await SaveAsync(model.Application, result, connection, transaction, cancellationToken);
                await SaveModulesAsync(model.Modules, result, connection, transaction, cancellationToken);
                await SaveUserApplicationsAsync(model.UserApplications, result, connection, transaction, cancellationToken);
                await DeleteModulesAsync(model.DeletedModules, result, connection, transaction, cancellationToken);
                await DeleteUserApplicationsAsync(model.DeletedUserApplications, result, connection, transaction, cancellationToken);
                transaction.Commit();
                return result;
            }
            catch (Exception ex)
            {
                ThrowError(ex);
                return default;
            }
        }

        private async Task SaveAsync(Application application, SaveApplicationResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            var _application = await _query.ExecuteAsync(application, connection, transaction, cancellationToken);

            if (_application is null)
                throw SorschiaException.VariableIsNull<Application>(nameof(_application));

            result.Application = _application;
        }

        private async Task SaveModulesAsync(IList<Module> modules, SaveApplicationResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (modules != null && modules.Count > 0)
                foreach (var module in modules)
                {
                    module.ApplicationId = result.Application.Id;
                    await SaveModuleAsync(module, result, connection, transaction, cancellationToken);
                }
        }

        private async Task SaveModuleAsync(Module module, SaveApplicationResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            var _module = await _saveModuleQuery.ExecuteAsync(module, connection, transaction, cancellationToken);

            if (_module is null)
                throw SorschiaException.VariableIsNull<Module>(nameof(_module));

            result.Modules.Add(_module);
        }

        private async Task SaveUserApplicationsAsync(IList<UserApplication> userApplications, SaveApplicationResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (userApplications != null && userApplications.Count > 0)
                foreach (var userApplication in userApplications)
                {
                    userApplication.ApplicationId = result.Application.Id;
                    await SaveUserApplicationAsync(userApplication, result, connection, transaction, cancellationToken);
                }
        }

        private async Task SaveUserApplicationAsync(UserApplication userApplication, SaveApplicationResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            var _userApplication = await _saveUserApplicationQuery.ExecuteAsync(userApplication, connection, transaction, cancellationToken);

            if (_userApplication is null)
                throw SorschiaException.VariableIsNull<UserApplication>(nameof(_userApplication));

            result.UserApplications.Add(_userApplication);
        }

        private async Task DeleteModulesAsync(IList<DeleteModuleModel> models, SaveApplicationResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (models != null && models.Count > 0)
                foreach (var model in models)
                    await DeleteModuleAsync(model, result, connection, transaction, cancellationToken);
        }

        private async Task DeleteModuleAsync(DeleteModuleModel model, SaveApplicationResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (await _deleteModuleQuery.ExecuteAsync(model, connection, transaction, cancellationToken))
                result.DeletedModuleIds.Add(model.Id);
        }

        private async Task DeleteUserApplicationsAsync(IList<DeleteUserApplicationModel> models, SaveApplicationResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (models != null && models.Count > 0)
                foreach (var model in models)
                    await DeleteUserApplicationAsync(model, result, connection, transaction, cancellationToken);
        }

        private async Task DeleteUserApplicationAsync(DeleteUserApplicationModel model, SaveApplicationResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (await _deleteUserApplicationQuery.ExecuteAsync(model, connection, transaction, cancellationToken))
                result.DeletedUserApplicationIds.Add(model.Id);
        }
    }
}
