using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Queries
{
    internal sealed class SaveUserApplicationQuery
    {
        private const string PROCEDURE = "[SystemCore].[SaveUserApplication]";
        private const string PARAM_ID = "@Id";
        private const string PARAM_USERID = "@UserId";
        private const string PARAM_APPLICATIONID = "@ApplicationId";
        private const string PARAM_ISAPPROVED = "@IsApproved";
        private const string PARAM_EXPIRATION = "@Expiration";
        private const string PARAM_ISEXPIRED = "@IsExpired";

        private readonly ISessionProvider _sessionProvider;

        public SaveUserApplicationQuery(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        public async Task<UserApplication> ExecuteAsync(UserApplication userApplication, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(userApplication, connection, transaction);
            await command.ExecuteNonQueryAsync(cancellationToken);
            userApplication.Id = command.Parameters.GetInt64(PARAM_ID);
            return userApplication.Id != 0 ? userApplication : null;
        }

        private SqlCommand CreateCommand(UserApplication userApplication, SqlConnection connection, SqlTransaction transaction) => connection
            .CreateProcedureCommand(PROCEDURE, transaction)
            .AddInOutParameter(PARAM_ID, userApplication.Id, SqlDbType.BigInt)
            .AddInParameter(PARAM_USERID, userApplication.UserId)
            .AddInParameter(PARAM_APPLICATIONID, userApplication.ApplicationId)
            .AddInParameter(PARAM_ISAPPROVED, userApplication.IsApproved)
            .AddInParameter(PARAM_EXPIRATION, userApplication.Expiration)
            .AddInParameter(PARAM_ISEXPIRED, userApplication.IsExpired)
            .AddSessionIdParameter(_sessionProvider);
    }
}
