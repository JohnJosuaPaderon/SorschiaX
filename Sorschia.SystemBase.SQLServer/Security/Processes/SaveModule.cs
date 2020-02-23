using Sorschia.Data;
using Sorschia.SystemBase.Data;
using Sorschia.SystemBase.Security.CommandProviders;
using Sorschia.SystemBase.Security.Entities;
using Sorschia.SystemBase.Security.ParameterProviders;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemBase.Security.Processes
{
    internal sealed class SaveModule : SQLProcessBase, ISaveModule
    {
        public SaveModule(
            IConnectionStringProvider connectionStringProvider,
            SaveModuleCommandProvider saveModuleCommandProvider,
            SaveModuleParameterProvider saveModuleParameterProvider,
            SaveUserModuleCommandProvider saveUserModuleCommandProvider,
            SaveUserModuleParameterProvider saveUserModuleParameterProvider,
            DeleteUserModuleCommandProvider deleteUserModuleCommandProvider) : base(connectionStringProvider.GetDefault())
        {
            _saveModuleCommandProvider = saveModuleCommandProvider;
            _saveModuleParameterProvider = saveModuleParameterProvider;
            _saveUserModuleCommandProvider = saveUserModuleCommandProvider;
            _saveUserModuleParameterProvider = saveUserModuleParameterProvider;
            _deleteUserModuleCommandProvider = deleteUserModuleCommandProvider;
        }

        private readonly SaveModuleCommandProvider _saveModuleCommandProvider;
        private readonly SaveModuleParameterProvider _saveModuleParameterProvider;
        private readonly SaveUserModuleCommandProvider _saveUserModuleCommandProvider;
        private readonly SaveUserModuleParameterProvider _saveUserModuleParameterProvider;
        private readonly DeleteUserModuleCommandProvider _deleteUserModuleCommandProvider;

        public SaveModuleModel Model { get; set; }

        #region SaveModule
        private async Task ExecuteSaveModuleAsync(SystemModule module, SaveModuleResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            using var command = _saveModuleCommandProvider.Get(module, connection, transaction);

            if (await command.ExecuteNonQueryAsync(cancellationToken) == 1)
            {
                module.Id = command.Parameters.GetInt32(_saveModuleParameterProvider.Id);
                result.Module = module;
            }
        }
        #endregion

        #region SaveUserModule
        private async Task ExecuteSaveUserModuleAsync(SystemUserModule userModule, SaveModuleResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            using var command = _saveUserModuleCommandProvider.Get(userModule, connection, transaction);

            if (await command.ExecuteNonQueryAsync(cancellationToken) == 1)
            {
                userModule.Id = command.Parameters.GetInt64(_saveUserModuleParameterProvider.Id);
                result.UserModuleList.Add(userModule);
            }
        }

        private async Task ExecuteSaveUserModuleListAsync(IList<SystemUserModule> userModuleList, SaveModuleResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (userModuleList != null && userModuleList.Any())
            {
                foreach (var userModule in userModuleList)
                {
                    userModule.ModuleId = result.Module.Id;
                    await ExecuteSaveUserModuleAsync(userModule, result, connection, transaction, cancellationToken);
                }
            }
        }
        #endregion

        #region DeleteUserModule
        private async Task ExecuteDeleteUserModuleAsync(long id, SaveModuleResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            using var command = _deleteUserModuleCommandProvider.Get(id, connection, transaction);

            if (await command.ExecuteNonQueryAsync(cancellationToken) == 1)
                result.DeletedUserModuleIdList.Add(id);
        }

        private async Task ExecuteDeleteUserModuleListAsync(IList<long> idList, SaveModuleResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (idList != null && idList.Any())
            {
                foreach (var id in idList)
                    await ExecuteDeleteUserModuleAsync(id, result, connection, transaction, cancellationToken);
            }
        }
        #endregion

        public async Task<SaveModuleResult> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = Model;
                var result = new SaveModuleResult();
                using var connection = await OpenConnectionAsync(cancellationToken);
                using var transaction = connection.BeginTransaction();
                await ExecuteSaveModuleAsync(model.Module, result, connection, transaction, cancellationToken);
                await ExecuteSaveUserModuleListAsync(model.UserModuleList, result, connection, transaction, cancellationToken);
                await ExecuteDeleteUserModuleListAsync(model.DeletedUserModuleIdList, result, connection, transaction, cancellationToken);
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
