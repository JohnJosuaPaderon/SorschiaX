using Sorschia.Data;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Queries
{
    internal sealed class SaveRefreshTokenQuery
    {
        private const string PROCEDURE = "[SystemCore].[SaveRefreshToken]";
        private const string PARAM_ID = "@Id";
        private const string PARAM_ACCESSTOKENID = "@AccessTokenId";
        private const string PARAM_TOKENSTRING = "@TokenString";
        private const int AFFECTEDROWS = 1;

        public async Task<RefreshToken> ExecuteAsync(RefreshToken refreshToken, SqlConnection connection, SqlTransaction transaction = default, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(refreshToken, connection, transaction);

            if (await command.ExecuteNonQueryAsync(cancellationToken) == AFFECTEDROWS)
            {
                refreshToken.Id = command.Parameters.GetGuid(PARAM_ID);
                return refreshToken;
            }

            return null;
        }

        private SqlCommand CreateCommand(RefreshToken refreshToken, SqlConnection connection, SqlTransaction transaction = default) => connection
            .CreateProcedureCommand(PROCEDURE, transaction)
            .AddInOutParameter(PARAM_ID, refreshToken.Id, SqlDbType.UniqueIdentifier)
            .AddInParameter(PARAM_ACCESSTOKENID, refreshToken.AccessTokenId)
            .AddInParameter(PARAM_TOKENSTRING, refreshToken.TokenString);
    }
}
