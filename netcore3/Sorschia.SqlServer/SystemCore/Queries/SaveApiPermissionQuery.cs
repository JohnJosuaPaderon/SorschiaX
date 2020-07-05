using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Queries
{
    internal sealed class SaveApiPermissionQuery
    {
        private const string PROCEDURE = "[SystemCore].[SaveApiPermission]";
        private const string PARAM_ID = "@Id";
        private const string PARAM_DESCRIPTION = "@Description";
        private const string PARAM_TYPEID = "@TypeId";
        private const string PARAM_GROUPID = "@GroupId";
        private const string PARAM_CONTROLLER = "@Controller";
        private const string PARAM_ACTION = "@Action";
        private const int AFFECTEDROWS = 1;

        private readonly ISessionProvider _sessionProvider;

        public SaveApiPermissionQuery(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        public async Task<ApiPermission> ExecuteAsync(ApiPermission permission, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(permission, connection, transaction);

            if (await command.ExecuteNonQueryAsync(cancellationToken) == AFFECTEDROWS)
            {
                permission.Id = command.Parameters.GetInt32(PARAM_ID);
                return permission;
            }

            return default;
        }

        private SqlCommand CreateCommand(ApiPermission permission, SqlConnection connection, SqlTransaction transaction) => connection
            .CreateProcedureCommand(PROCEDURE, transaction)
            .AddInOutParameter(PARAM_ID, permission.Id, SqlDbType.Int)
            .AddInParameter(PARAM_DESCRIPTION, permission.Description)
            .AddInParameter(PARAM_TYPEID, permission.TypeId)
            .AddInParameter(PARAM_GROUPID, permission.GroupId)
            .AddInParameter(PARAM_CONTROLLER, permission.Controller)
            .AddInParameter(PARAM_ACTION, permission.Action)
            .AddSessionIdParameter(_sessionProvider);
    }
}
