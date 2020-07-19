using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Queries
{
    internal sealed class SavePermissionQuery
    {
        private const string PROCEDURE = "[SystemCore].[SavePermission]";
        private const string PARAM_ID = "@Id";
        private const string PARAM_DESCRIPTION = "@Description";
        private const string PARAM_GROUPID = "@GroupId";
        private const int AFFECTEDROWS = 1;

        private readonly ISessionProvider _sessionProvider;

        public SavePermissionQuery(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        public async Task<Permission> ExecuteAsync(Permission permission, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(permission, connection, transaction);

            if (await command.ExecuteNonQueryAsync(cancellationToken) == AFFECTEDROWS)
            {
                permission.Id = command.Parameters.GetInt32(PARAM_ID);
                return permission;
            }

            return default;
        }

        private SqlCommand CreateCommand(Permission permission, SqlConnection connection, SqlTransaction transaction) => connection
            .CreateProcedureCommand(PROCEDURE, transaction)
            .AddInOutParameter(PARAM_ID, permission.Id, SqlDbType.Int)
            .AddInParameter(PARAM_DESCRIPTION, permission.Description)
            .AddInParameter(PARAM_GROUPID, permission.GroupId)
            .AddSessionIdParameter(_sessionProvider);
    }
}
