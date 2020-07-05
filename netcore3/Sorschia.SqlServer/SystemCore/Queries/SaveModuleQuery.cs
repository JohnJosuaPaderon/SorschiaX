using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Queries
{
    internal sealed class SaveModuleQuery
    {
        private const string PROCEDURE = "[SystemCore].[SaveModule]";
        private const string PARAM_ID = "@Id";
        private const string PARAM_NAME = "@Name";
        private const string PARAM_ORDINALNUMBER = "@OrdinalNumber";
        private const string PARAM_APPLICATIONID = "@ApplicationId";
        private const int AFFECTEDROWS = 1;

        private readonly ISessionProvider _sessionProvider;

        public SaveModuleQuery(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        public async Task<Module> ExecuteAsync(Module module, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(module, connection, transaction);

            if (await command.ExecuteNonQueryAsync(cancellationToken) == AFFECTEDROWS)
            {
                module.Id = command.Parameters.GetInt32(PARAM_ID);
                return module;
            }

            return null;
        }

        private SqlCommand CreateCommand(Module module, SqlConnection connection, SqlTransaction transaction) => connection
            .CreateProcedureCommand(PROCEDURE, transaction)
            .AddInOutParameter(PARAM_ID, module.Id, SqlDbType.Int)
            .AddInParameter(PARAM_NAME, module.Name)
            .AddInParameter(PARAM_ORDINALNUMBER, module.OrdinalNumber)
            .AddInParameter(PARAM_APPLICATIONID, module.ApplicationId)
            .AddSessionIdParameter(_sessionProvider);
    }
}
