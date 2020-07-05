using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Queries
{
    internal sealed class SaveUserPermissionQuery
    {
        private const string PROCEDURE = "[SystemCore].[SaveUserPermission]";
        private const string PARAM_ID = "@Id";
        private const string PARAM_USERID = "@UserId";
        private const string PARAM_MODULEID = "@PermissionId";
        private const string PARAM_ISAPPROVED = "@IsApproved";
        private const string PARAM_EXPIRATION = "@Expiration";
        private const string PARAM_ISEXPIRED = "@IsExpired";
        private const int AFFECTEDROWS = 1;

        private readonly ISessionProvider _sessionProvider;

        public SaveUserPermissionQuery(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        public async Task<UserPermission> ExecuteAsync(UserPermission userPermission, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(userPermission, connection, transaction);

            if (await command.ExecuteNonQueryAsync(cancellationToken) == AFFECTEDROWS)
            {
                userPermission.Id = command.Parameters.GetInt64(PARAM_ID);
                return userPermission;
            }

            return default;
        }

        private SqlCommand CreateCommand(UserPermission userPermission, SqlConnection connection, SqlTransaction transaction) => connection
            .CreateProcedureCommand(PROCEDURE, transaction)
            .AddInOutParameter(PARAM_ID, userPermission.Id, SqlDbType.BigInt)
            .AddInParameter(PARAM_USERID, userPermission.UserId)
            .AddInParameter(PARAM_MODULEID, userPermission.PermissionId)
            .AddInParameter(PARAM_ISAPPROVED, userPermission.IsApproved)
            .AddInParameter(PARAM_EXPIRATION, userPermission.Expiration)
            .AddInParameter(PARAM_ISEXPIRED, userPermission.IsExpired)
            .AddSessionIdParameter(_sessionProvider);
    }
}
