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
        private const int AFFECTEDROWS = 1;

        public async Task<AccessToken> ExecuteAsync(AccessToken accessToken, SqlConnection connection, SqlTransaction transaction = default, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(accessToken, connection, transaction);

            if (await command.ExecuteNonQueryAsync(cancellationToken) == AFFECTEDROWS)
            {
                accessToken.Id = command.Parameters.GetGuid(PARAM_ID);
                return accessToken;
            }

            return null;
        }

        private SqlCommand CreateCommand(AccessToken accessToken, SqlConnection connection, SqlTransaction transaction = default) => connection
            .CreateProcedureCommand(PROCEDURE, transaction)
            .AddInOutParameter(PARAM_ID, accessToken.Id, SqlDbType.UniqueIdentifier)
            .AddInParameter(PARAM_SESSIONID, accessToken.SessionId)
            .AddInParameter(PARAM_TOKENSTRING, accessToken.TokenString)
            .AddInParameter(PARAM_EXPIRATION, accessToken.Expiration);
    }
}
