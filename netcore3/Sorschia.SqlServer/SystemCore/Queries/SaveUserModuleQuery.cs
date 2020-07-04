using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Queries
{
    internal sealed class SaveUserModuleQuery
    {
        private const string PROCEDURE = "[SystemCore].[SaveUserModule]";
        private const string PARAM_ID = "@Id";
        private const string PARAM_USERID = "@UserId";
        private const string PARAM_MODULEID = "@ModuleId";
        private const string PARAM_ISAPPROVED = "@IsApproved";
        private const string PARAM_EXPIRATION = "@Expiration";
        private const string PARAM_ISEXPIRED = "@IsExpired";
        private const int AFFECTEDROWS = 1;

        private readonly ISessionProvider _sessionProvider;

        public SaveUserModuleQuery(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        public async Task<UserModule> ExecuteAsync(UserModule userModule, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(userModule, connection, transaction);

            if (await command.ExecuteNonQueryAsync(cancellationToken) == AFFECTEDROWS)
            {
                userModule.Id = command.Parameters.GetInt64(PARAM_ID);
                return userModule;
            }

            return default;
        }

        private SqlCommand CreateCommand(UserModule userModule, SqlConnection connection, SqlTransaction transaction) => connection
            .CreateProcedureCommand(PROCEDURE, transaction)
            .AddInOutParameter(PARAM_ID, userModule.Id, SqlDbType.BigInt)
            .AddInParameter(PARAM_USERID, userModule.UserId)
            .AddInParameter(PARAM_MODULEID, userModule.ModuleId)
            .AddInParameter(PARAM_ISAPPROVED, userModule.IsApproved)
            .AddInParameter(PARAM_EXPIRATION, userModule.Expiration)
            .AddInParameter(PARAM_ISEXPIRED, userModule.IsExpired)
            .AddSessionIdParameter(_sessionProvider);
    }
}
