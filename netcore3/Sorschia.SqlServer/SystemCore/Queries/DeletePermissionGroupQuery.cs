using Sorschia.Data;
using Sorschia.SystemCore.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Queries
{
    internal sealed class DeletePermissionGroupQuery
    {
        private const string PROCEDURE = "[SystemCore].[DeletePermissionGroup]";
        private const string PARAM_ID = "@Id";
        private const string PARAM_ISCASCADED = "@IsCascaded";
        private const int AFFECTEDROWS = 1;

        private readonly ISessionProvider _sessionProvider;

        public DeletePermissionGroupQuery(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        public async Task<bool> ExecuteAsync(DeletePermissionGroupModel model, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(model, connection, transaction);
            return await command.ExecuteNonQueryAsync(cancellationToken) == AFFECTEDROWS;
        }

        private SqlCommand CreateCommand(DeletePermissionGroupModel model, SqlConnection connection, SqlTransaction transaction) => connection
            .CreateProcedureCommand(PROCEDURE, transaction)
            .AddInParameter(PARAM_ID, model.Id)
            .AddInParameter(PARAM_ISCASCADED, model.IsCascaded)
            .AddSessionIdParameter(_sessionProvider);
    }

}
