using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
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
        private const int AFFECTEDROWS = 1;

        private readonly ISessionProvider _sessionProvider;

        public SaveUserApplicationQuery(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        public async Task<UserApplication> ExecuteAsync(UserApplication userApplication, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(userApplication, connection, transaction);

            if (await command.ExecuteNonQueryAsync(cancellationToken) == AFFECTEDROWS)
            {
                userApplication.Id = command.Parameters.GetInt64(PARAM_ID);
                return userApplication;
            }

            return null;
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
