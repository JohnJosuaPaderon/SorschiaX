using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Queries
{
    internal sealed class SaveApplicationQuery
    {
        private const string PROCEDURE = "[SystemCore].[SaveApplication]";
        private const string PARAM_ID = "@Id";
        private const string PARAM_NAME = "@Name";
        private const string PARAM_PLATFORMID = "@PlatformId";

        private readonly ISessionProvider _sessionProvider;

        public SaveApplicationQuery(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        public async Task<Application> ExecuteAsync(Application application, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(application, connection, transaction);
            await command.ExecuteNonQueryAsync(cancellationToken);
            application.Id = command.Parameters.GetInt32(PARAM_ID);
            return application.Id != 0 ? application : null;
        }

        private SqlCommand CreateCommand(Application application, SqlConnection connection, SqlTransaction transaction) => connection
            .CreateProcedureCommand(PROCEDURE, transaction)
            .AddInOutParameter(PARAM_ID, application.Id, SqlDbType.Int)
            .AddInParameter(PARAM_NAME, application.Name)
            .AddInParameter(PARAM_PLATFORMID, application.PlatformId)
            .AddSessionIdParameter(_sessionProvider);
    }
}
