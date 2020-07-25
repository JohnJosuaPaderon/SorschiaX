using Sorschia.Data;
using Sorschia.SystemCore.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Queries
{
    internal sealed class DeleteUserPermissionQuery
    {
        private const string PROCEDURE = "[SystemCore].[DeleteUserPermission]";
        private const string PARAM_ID = "@Id";
        private const string PARAM_ISCASCADED = "@IsCascaded";

        private readonly ISessionProvider _sessionProvider;

        public DeleteUserPermissionQuery(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        public async Task<bool> ExecuteAsync(DeleteUserPermissionModel model, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(model, connection, transaction);
            await command.ExecuteNonQueryAsync(cancellationToken);
            return true;
        }

        private SqlCommand CreateCommand(DeleteUserPermissionModel model, SqlConnection connection, SqlTransaction transaction) => connection
            .CreateProcedureCommand(PROCEDURE, transaction)
            .AddInParameter(PARAM_ID, model.Id)
            .AddInParameter(PARAM_ISCASCADED, model.IsCascaded)
            .AddSessionIdParameter(_sessionProvider);
    }
}
