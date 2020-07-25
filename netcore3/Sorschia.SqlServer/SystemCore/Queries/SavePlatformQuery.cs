using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Queries
{
    internal sealed class SavePlatformQuery
    {
        private const string PROCEDURE = "[SystemCore].[SavePlatform]";
        private const string PARAM_ID = "@Id";
        private const string PARAM_NAME = "@Name";
        private const int AFFECTEDROWS = 1;

        private readonly ISessionProvider _sessionProvider;

        public SavePlatformQuery(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        public async Task<Platform> ExecuteAsync(Platform module, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(module, connection, transaction);
            await command.ExecuteNonQueryAsync(cancellationToken);
            module.Id = command.Parameters.GetInt32(PARAM_ID);
            return module.Id != 0 ? module : null;
        }

        private SqlCommand CreateCommand(Platform module, SqlConnection connection, SqlTransaction transaction) => connection
            .CreateProcedureCommand(PROCEDURE, transaction)
            .AddInOutParameter(PARAM_ID, module.Id, SqlDbType.Int)
            .AddInParameter(PARAM_NAME, module.Name)
            .AddSessionIdParameter(_sessionProvider);
    }
}
