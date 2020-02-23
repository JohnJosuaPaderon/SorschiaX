using Sorschia.Data;
using Sorschia.SystemBase.Data;
using Sorschia.SystemBase.Security.CommandProviders;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemBase.Security.Processes
{
    internal sealed class DeleteApplicationPlatform : SQLProcessBase, IDeleteApplicationPlatform
    {
        public DeleteApplicationPlatform(
            IConnectionStringProvider connectionStringProvider, 
            DeleteApplicationPlatformCommandProvider deleteApplicationPlatformCommandProvider) : base(connectionStringProvider.GetDefault())
        {
            _deleteApplicationPlatformCommandProvider = deleteApplicationPlatformCommandProvider;
        }

        private readonly DeleteApplicationPlatformCommandProvider _deleteApplicationPlatformCommandProvider;

        public DeleteApplicationPlatformModel Model { get; set; }

        private async Task<bool> ExecuteDeleteApplicationPlatformAsync(DeleteApplicationPlatformModel model, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            using var command = _deleteApplicationPlatformCommandProvider.Get(model, connection, transaction);
            return await command.ExecuteNonQueryAsync(cancellationToken) == 1;
        }

        public async Task<bool> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = Model;
                using var connection = await OpenConnectionAsync(cancellationToken);
                using var transaction = connection.BeginTransaction();
                var result = await ExecuteDeleteApplicationPlatformAsync(model, connection, transaction, cancellationToken);
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
