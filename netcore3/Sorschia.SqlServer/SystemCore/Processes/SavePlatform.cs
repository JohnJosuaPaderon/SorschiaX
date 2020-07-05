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
    internal sealed class SavePlatform : ProcessBase, ISavePlatform
    {
        private readonly SavePlatformQuery _query;
        private readonly SaveApplicationQuery _saveApplicationQuery;
        private readonly DeleteApplicationQuery _deleteApplicationQuery;

        public SavePlatformModel Model { get; set; }

        public SavePlatform(IConnectionStringProvider connectionStringProvider,
            SavePlatformQuery query,
            SaveApplicationQuery saveApplicationQuery,
            DeleteApplicationQuery deleteApplicationQuery) : base(connectionStringProvider)
        {
            _query = query;
            _saveApplicationQuery = saveApplicationQuery;
            _deleteApplicationQuery = deleteApplicationQuery;
        }

        public async Task<SavePlatformResult> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = ObjectCopy.Copy(Model);
                var result = new SavePlatformResult();
                using var connection = await OpenConnectionAsync(cancellationToken);
                using var transaction = connection.BeginTransaction();
                await SaveAsync(model.Platform, result, connection, transaction, cancellationToken);
                await SaveApplicationsAsync(model.Applications, result, connection, transaction, cancellationToken);
                await DeleteApplicationsAsync(model.DeletedApplications, result, connection, transaction, cancellationToken);
                transaction.Commit();
                return result;
            }
            catch (Exception ex)
            {
                ThrowError(ex);
                return default;
            }
        }

        private async Task SaveAsync(Platform platform, SavePlatformResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            var _platform = await _query.ExecuteAsync(platform, connection, transaction, cancellationToken);

            if (_platform is null)
                throw SorschiaException.VariableIsNull<Platform>(nameof(_platform));

            result.Platform = _platform;
        }

        private async Task SaveApplicationsAsync(IList<Application> applications, SavePlatformResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (applications != null && applications.Count > 0)
                foreach (var application in applications)
                {
                    application.PlatformId = result.Platform.Id;
                    await SaveApplicationAsync(application, result, connection, transaction, cancellationToken);
                }
        }

        private async Task SaveApplicationAsync(Application application, SavePlatformResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            var _application = await _saveApplicationQuery.ExecuteAsync(application, connection, transaction, cancellationToken);

            if (_application is null)
                throw SorschiaException.VariableIsNull<Application>(nameof(_application));

            result.Applications.Add(_application);
        }

        public async Task DeleteApplicationsAsync(IList<DeleteApplicationModel> models, SavePlatformResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (models != null && models.Count > 0)
                foreach (var model in models)
                    await DeleteApplicationAsync(model, result, connection, transaction, cancellationToken);
        }

        private async Task DeleteApplicationAsync(DeleteApplicationModel model, SavePlatformResult result, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            if (await _deleteApplicationQuery.ExecuteAsync(model, connection, transaction, cancellationToken))
                result.DeletedApplicationIds.Add(model.Id);
        }
    }
}
