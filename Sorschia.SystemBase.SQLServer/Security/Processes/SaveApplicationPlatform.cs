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
    internal sealed class SaveApplicationPlatform : SQLProcessBase, ISaveApplicationPlatform
    {
        public SaveApplicationPlatform(
            IConnectionStringProvider connectionStringProvider,
            SaveApplicationPlatformCommandProvider saveApplicationPlatformCommandProvider,
            SaveApplicationPlatformParameterProvider saveApplicationPlatformParameterProvider,
            SaveApplicationCommandProvider saveApplicationCommandProvider,
            SaveApplicationParameterProvider saveApplicationParameterProvider,
            RemoveApplicationFromPlatformCommandProvider removeApplicationFromPlatformCommandProvider) : base(connectionStringProvider.GetDefault())
        {
            _saveApplicationPlatformCommandProvider = saveApplicationPlatformCommandProvider;
            _saveApplicationPlatformParameterProvider = saveApplicationPlatformParameterProvider;
            _saveApplicationCommandProvider = saveApplicationCommandProvider;
            _saveApplicationParameterProvider = saveApplicationParameterProvider;
            _removeApplicationFromPlatformCommandProvider = removeApplicationFromPlatformCommandProvider;
        }

        private readonly SaveApplicationPlatformCommandProvider _saveApplicationPlatformCommandProvider;
        private readonly SaveApplicationPlatformParameterProvider _saveApplicationPlatformParameterProvider;
        private readonly SaveApplicationCommandProvider _saveApplicationCommandProvider;
        private readonly SaveApplicationParameterProvider _saveApplicationParameterProvider;
        private readonly RemoveApplicationFromPlatformCommandProvider _removeApplicationFromPlatformCommandProvider;

        public SaveApplicationPlatformModel Model { get; set; }

        #region SaveApplicationPlatform
        private async Task ExecuteSaveApplicationPlatformAsync(SystemApplicationPlatform applicationPlatform, SaveApplicationPlatformResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            using var command = _saveApplicationPlatformCommandProvider.Get(applicationPlatform, connection, transaction);

            if (await command.ExecuteNonQueryAsync(cancellationToken) == 1)
            {
                applicationPlatform.Id = command.Parameters.GetInt32(_saveApplicationPlatformParameterProvider.Id);
                result.ApplicationPlatform = applicationPlatform;
            }
        }
        #endregion

        #region SaveApplication
        private async Task ExecuteSaveApplicationAsync(SystemApplication application, SaveApplicationPlatformResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            using var command = _saveApplicationCommandProvider.Get(application, connection, transaction);

            if (await command.ExecuteNonQueryAsync(cancellationToken) == 1)
            {
                application.Id = command.Parameters.GetInt32(_saveApplicationParameterProvider.Id);
                result.ApplicationList.Add(application);
            }
        }

        private async Task ExecuteSaveApplicationListAsync(IList<SystemApplication> applicationList, SaveApplicationPlatformResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (applicationList != null && applicationList.Any())
                foreach (var application in applicationList)
                {
                    application.PlatformId = result.ApplicationPlatform.Id;
                    await ExecuteSaveApplicationAsync(application, result, connection, transaction, cancellationToken);
                }
        }
        #endregion

        #region RemoveApplicationFromPlatform
        private async Task ExecuteRemoveApplicationFromPlatformAsync(int applicationId, SaveApplicationPlatformResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            using var command = _removeApplicationFromPlatformCommandProvider.Get(applicationId, connection, transaction);

            if (await command.ExecuteNonQueryAsync(cancellationToken) == 1)
                result.RemovedApplicationIdList.Add(applicationId);
        }

        private async Task ExecuteRemoveApplicationListFromPlatformAsync(IList<int> applicationIdList, SaveApplicationPlatformResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (applicationIdList != null && applicationIdList.Any())
                foreach (var applicationId in applicationIdList)
                    await ExecuteRemoveApplicationFromPlatformAsync(applicationId, result, connection, transaction, cancellationToken);
        }
        #endregion

        public async Task<SaveApplicationPlatformResult> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = Model;
                var result = new SaveApplicationPlatformResult();
                using var connection = await OpenConnectionAsync(cancellationToken);
                using var transaction = connection.BeginTransaction();
                await ExecuteSaveApplicationPlatformAsync(model.ApplicationPlatform, result, connection, transaction, cancellationToken);
                await ExecuteSaveApplicationListAsync(model.ApplicationList, result, connection, transaction, cancellationToken);
                await ExecuteRemoveApplicationListFromPlatformAsync(model.RemovedApplicationIdList, result, connection, transaction, cancellationToken);
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
