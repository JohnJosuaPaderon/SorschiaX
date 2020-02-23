using Sorschia.Data;
using Sorschia.SystemBase.Data;
using Sorschia.SystemBase.Security.CommandProviders;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemBase.Security.Processes
{
    internal sealed class DeleteModule : SQLProcessBase, IDeleteModule
    {
        public DeleteModule(
            IConnectionStringProvider connectionStringProvider, 
            DeleteModuleCommandProvider deleteModuleCommandProvider) : base(connectionStringProvider.GetDefault())
        {
            _deleteModuleCommandProvider = deleteModuleCommandProvider;
        }

        private readonly DeleteModuleCommandProvider _deleteModuleCommandProvider;

        public DeleteModuleModel Model { get; set; }

        private async Task<bool> ExecuteDeleteModuleAsync(DeleteModuleModel model, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            using var command = _deleteModuleCommandProvider.Get(model, connection, transaction);
            return await command.ExecuteNonQueryAsync(cancellationToken) == 1;
        }

        public async Task<bool> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = Model;
                using var connection = await OpenConnectionAsync(cancellationToken);
                using var transaction = connection.BeginTransaction();
                var result = await ExecuteDeleteModuleAsync(model, connection, transaction, cancellationToken);
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
