using Sorschia.Data;
using Sorschia.SystemBase.Data;
using Sorschia.SystemBase.Security.CommandProviders;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemBase.Security.Processes
{
    internal sealed class DeleteUser : SqlProcessBase, IDeleteUser
    {
        public DeleteUser(
            IConnectionStringProvider connectionStringProvider, 
            DeleteUserCommandProvider deleteUserCommandProvider) : base(connectionStringProvider.GetDefault())
        {
            _deleteUserCommandProvider = deleteUserCommandProvider;
        }

        private readonly DeleteUserCommandProvider _deleteUserCommandProvider;

        public DeleteUserModel Model { get; set; }

        private async Task<bool> ExecuteDeleteUserAsync(DeleteUserModel model, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken)
        {
            using var command = _deleteUserCommandProvider.Get(model, connection, transaction);
            return await command.ExecuteNonQueryAsync(cancellationToken) == 1;
        }

        public async Task<bool> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var model = Model;
                using var connection = await OpenConnectionAsync(cancellationToken);
                using var transaction = connection.BeginTransaction();
                var result = await ExecuteDeleteUserAsync(model, connection, transaction, cancellationToken);
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
