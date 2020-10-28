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

        private readonly ISessionIdProvider _sessionIdProvider;

        public SaveUserPermissionQuery(ISessionIdProvider sessionIdProvider)
        {
            _sessionIdProvider = sessionIdProvider;
        }

        public async Task<UserPermission> ExecuteAsync(UserPermission userPermission, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(userPermission, connection, transaction);
            await command.ExecuteNonQueryAsync(cancellationToken);
            userPermission.Id = command.Parameters.GetInt64(PARAM_ID);
            return userPermission.Id != 0 ? userPermission : null;
        }

        private SqlCommand CreateCommand(UserPermission userPermission, SqlConnection connection, SqlTransaction transaction) => connection
            .CreateProcedureCommand(PROCEDURE, transaction)
            .AddInOutParameter(PARAM_ID, userPermission.Id, SqlDbType.BigInt)
            .AddInParameter(PARAM_USERID, userPermission.UserId)
            .AddInParameter(PARAM_MODULEID, userPermission.PermissionId)
            .AddInParameter(PARAM_ISAPPROVED, userPermission.IsApproved)
            .AddInParameter(PARAM_EXPIRATION, userPermission.Expiration)
            .AddInParameter(PARAM_ISEXPIRED, userPermission.IsExpired)
            .AddSessionIdParameter(_sessionIdProvider);
    }
}
