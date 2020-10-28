using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Queries
{
    internal sealed class SavePermissionGroupQuery
    {
        private const string PROCEDURE = "[SystemCore].[SavePermissionGroup]";
        private const string PARAM_ID = "@Id";
        private const string PARAM_NAME = "@Name";
        private const string PARAM_PARENTID = "@ParentId";

        private readonly ISessionIdProvider _sessionIdProvider;

        public SavePermissionGroupQuery(ISessionIdProvider sessionIdProvider)
        {
            _sessionIdProvider = sessionIdProvider;
        }

        public async Task<PermissionGroup> ExecuteAsync(PermissionGroup group, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(group, connection, transaction);
            await command.ExecuteNonQueryAsync(cancellationToken);
            group.Id = command.Parameters.GetInt32(PARAM_ID);
            return group.Id != 0 ? group : null;
        }

        private SqlCommand CreateCommand(PermissionGroup group, SqlConnection connection, SqlTransaction transaction) => connection
            .CreateProcedureCommand(PROCEDURE, transaction)
            .AddInOutParameter(PARAM_ID, group.Id, SqlDbType.Int)
            .AddInParameter(PARAM_NAME, group.Name)
            .AddInParameter(PARAM_PARENTID, group.ParentId)
            .AddSessionIdParameter(_sessionIdProvider);
    }
}
