using Sorschia.Data;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Queries
{
    internal sealed class SaveAccessTokenQuery
    {
        private const string PROCEDURE = "[SystemCore].[SaveAccessToken]";
        private const string PARAM_ID = "@Id";
        private const string PARAM_SESSIONID = "@SessionId";
        private const string PARAM_TOKENSTRING = "@TokenString";
        private const string PARAM_EXPIRATION = "@Expiration";

        public async Task<AccessToken> ExecuteAsync(AccessToken accessToken, SqlConnection connection, SqlTransaction transaction = default, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(accessToken, connection, transaction);
            await command.ExecuteNonQueryAsync(cancellationToken);
            accessToken.Id = command.Parameters.GetInt64(PARAM_ID);
            return accessToken.Id != 0 ? accessToken : null;
        }

        private SqlCommand CreateCommand(AccessToken accessToken, SqlConnection connection, SqlTransaction transaction = default) => connection
            .CreateProcedureCommand(PROCEDURE, transaction)
            .AddInOutParameter(PARAM_ID, accessToken.Id, SqlDbType.BigInt)
            .AddInParameter(PARAM_SESSIONID, accessToken.SessionId)
            .AddInParameter(PARAM_TOKENSTRING, accessToken.TokenString)
            .AddInParameter(PARAM_EXPIRATION, accessToken.Expiration);
    }
}
