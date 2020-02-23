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
    internal sealed class SaveApplication : SQLProcessBase, ISaveApplication
    {
        public SaveApplication(
            IConnectionStringProvider connectionStringProvider,
            DeleteUserApplicationCommandProvider deleteUserApplicationCommandProvider,
            RemoveModuleFromApplicationCommandProvider removeModuleFromApplicationCommandProvider,
            SaveApplicationCommandProvider saveApplicationCommandProvider,
            SaveModuleCommandProvider saveModuleCommandProvider,
            SaveUserApplicationCommandProvider saveUserApplicationCommandProvider,
            SaveApplicationParameterProvider saveApplicationParameterProvider,
            SaveModuleParameterProvider saveModuleParameterProvider, 
            SaveUserApplicationParameterProvider saveUserApplicationParameterProvider) : base(connectionStringProvider.GetDefault())
        {
            _deleteUserApplicationCommandProvider = deleteUserApplicationCommandProvider;
            _removeModuleFromApplicationCommandProvider = removeModuleFromApplicationCommandProvider;
            _saveApplicationCommandProvider = saveApplicationCommandProvider;
            _saveModuleCommandProvider = saveModuleCommandProvider;
            _saveUserApplicationCommandProvider = saveUserApplicationCommandProvider;
            _saveApplicationParameterProvider = saveApplicationParameterProvider;
            _saveModuleParameterProvider = saveModuleParameterProvider;
            _saveUserApplicationParameterProvider = saveUserApplicationParameterProvider;
        }

        private readonly DeleteUserApplicationCommandProvider _deleteUserApplicationCommandProvider;
        private readonly RemoveModuleFromApplicationCommandProvider _removeModuleFromApplicationCommandProvider;
        private readonly SaveApplicationCommandProvider _saveApplicationCommandProvider;
        private readonly SaveModuleCommandProvider _saveModuleCommandProvider;
        private readonly SaveUserApplicationCommandProvider _saveUserApplicationCommandProvider;
        private readonly SaveApplicationParameterProvider _saveApplicationParameterProvider;
        private readonly SaveModuleParameterProvider _saveModuleParameterProvider;
        private readonly SaveUserApplicationParameterProvider _saveUserApplicationParameterProvider;

        public SaveApplicationModel Model { get; set; }

        #region SaveApplication
        private async Task ExecuteSaveApplicationAsync(SystemApplication application, SaveApplicationResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            using var command = _saveApplicationCommandProvider.Get(application, connection, transaction);

            if (await command.ExecuteNonQueryAsync(cancellationToken) == 1)
            {
                application.Id = command.Parameters.GetInt32(_saveApplicationParameterProvider.Id);
                result.Application = application;
            }
        }
        #endregion

        #region SaveModule
        private async Task ExecuteSaveModuleAsync(SystemModule module, SaveApplicationResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            using var command = _saveModuleCommandProvider.Get(module, connection, transaction);

            if (await command.ExecuteNonQueryAsync(cancellationToken) == 1)
            {
                module.Id = command.Parameters.GetInt32(_saveModuleParameterProvider.Id);
                result.ModuleList.Add(module);
            }
        }

        private async Task ExecuteSaveModuleListAsync(IList<SystemModule> moduleList, SaveApplicationResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (moduleList != null && moduleList.Any())
                foreach (var module in moduleList)
                {
                    module.ApplicationId = result.Application.Id;
                    await ExecuteSaveModuleAsync(module, result, connection, transaction, cancellationToken);
                }
        }
        #endregion

        #region RemoveModuleFromApplication
        private async Task ExecuteRemoveModuleFromApplicationAsync(int moduleId, SaveApplicationResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            using var command = _removeModuleFromApplicationCommandProvider.Get(moduleId, connection, transaction);

            if (await command.ExecuteNonQueryAsync(cancellationToken) == 1)
                result.RemovedModuleIdList.Add(moduleId);
        }

        private async Task ExecuteRemoveModuleListFromApplicationAsync(IList<int> moduleIdList, SaveApplicationResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (moduleIdList != null && moduleIdList.Any())
                foreach (var moduleId in moduleIdList)
                    await ExecuteRemoveModuleFromApplicationAsync(moduleId, result, connection, transaction, cancellationToken);
        }

        #endregion

        #region SaveUserApplication
        private async Task ExecuteSaveUserApplicationAsync(SystemUserApplication userApplication, SaveApplicationResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            using var command = _saveUserApplicationCommandProvider.Get(userApplication, connection, transaction);

            if (await command.ExecuteNonQueryAsync(cancellationToken) == 1)
            {
                userApplication.Id = command.Parameters.GetInt64(_saveUserApplicationParameterProvider.Id);
                result.UserApplicationList.Add(userApplication);
            }
        }

        private async Task ExecuteSaveUserApplicationListAsync(IList<SystemUserApplication> userApplicationList, SaveApplicationResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (userApplicationList != null && userApplicationList.Any())
                foreach (var userApplication in userApplicationList)
                {
                    userApplication.ApplicationId = result.Application.Id;
                    await ExecuteSaveUserApplicationAsync(userApplication, result, connection, transaction, cancellationToken);
                }
        }
        #endregion

        #region DeleteUserApplication
        private async Task ExecuteDeleteUserApplicationAsync(long id, SaveApplicationResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            using var command = _deleteUserApplicationCommandProvider.Get(id, connection, transaction);

            if (await command.ExecuteNonQueryAsync(cancellationToken) == 1)
                result.DeletedUserApplicationIdList.Add(id);
        }

        private async Task ExecuteDeleteUserApplicationListAsync(IList<long> idList, SaveApplicationResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (idList != null && idList.Any())
                foreach (var id in idList)
                    await ExecuteDeleteUserApplicationAsync(id, result, connection, transaction, cancellationToken);
        }
        #endregion

        public async Task<SaveApplicationResult> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = Model;
                var result = new SaveApplicationResult();
                using var connection = await OpenConnectionAsync(cancellationToken);
                using var transaction = connection.BeginTransaction();
                await ExecuteSaveApplicationAsync(model.Application, result, connection, transaction, cancellationToken);
                await ExecuteSaveModuleListAsync(model.ModuleList, result, connection, transaction, cancellationToken);
                await ExecuteRemoveModuleListFromApplicationAsync(model.RemovedModuleIdList, result, connection, transaction, cancellationToken);
                await ExecuteSaveUserApplicationListAsync(model.UserApplicationList, result, connection, transaction, cancellationToken);
                await ExecuteDeleteUserApplicationListAsync(model.DeletedUserApplicationIdList, result, connection, transaction, cancellationToken);
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
