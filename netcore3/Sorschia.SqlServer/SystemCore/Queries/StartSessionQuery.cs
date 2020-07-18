using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Queries
{
    internal sealed class StartSessionQuery
    {
        private const string PROCEDURE = "[SystemCore].[StartSession]";
        private const string PARAM_ID = "@Id";
        private const string PARAM_USERID = "@UserId";
        private const string PARAM_APPLICATIONID = "@ApplicationId";
        private const string PARAM_MACADDRESS = "@MacAddress";
        private const string PARAM_IPADDRESS = "@IpAddress";
        private const string PARAM_OPERATINGSYSTEM = "@OperatingSystem";
        private const string PARAM_SESSIONSTART = "@SessionStart";
        private const int AFFECTEDROWS = 1;

        public async Task<Session> ExecuteAsync(Session session, SqlConnection connection, SqlTransaction transaction = default, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(session, connection, transaction);

            if (await command.ExecuteNonQueryAsync(cancellationToken) == AFFECTEDROWS)
            {
                session.Id = command.Parameters.GetGuid(PARAM_ID);
                session.SessionStart = command.Parameters.GetDateTime(PARAM_SESSIONSTART);
                return session;
            }

            return null;
        }

        private SqlCommand CreateCommand(Session session, SqlConnection connection, SqlTransaction transaction = default) => connection
            .CreateProcedureCommand(PROCEDURE, transaction)
            .AddOutParameter(PARAM_ID, SqlDbType.UniqueIdentifier)
            .AddOutParameter(PARAM_SESSIONSTART, SqlDbType.DateTime)
            .AddInParameter(PARAM_USERID, session.UserId)
            .AddInParameter(PARAM_APPLICATIONID, session.ApplicationId)
            .AddInParameter(PARAM_MACADDRESS, session.MacAddress)
            .AddInParameter(PARAM_IPADDRESS, session.IpAddress)
            .AddInParameter(PARAM_OPERATINGSYSTEM, session.Operatingsystem);
    }
}
