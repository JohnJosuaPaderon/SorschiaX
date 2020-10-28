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
        private const string PARAM_ROUTEURL = "@RouteUrl";
        
        private readonly ISessionIdProvider _sessionIdProvider;

        public SaveModuleQuery(ISessionIdProvider sessionIdProvider)
        {
            _sessionIdProvider = sessionIdProvider;
        }

        public async Task<Module> ExecuteAsync(Module module, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(module, connection, transaction);
            await command.ExecuteNonQueryAsync(cancellationToken);
            module.Id = command.Parameters.GetInt32(PARAM_ID);
            return module.Id != 0 ? module : null;
        }

        private SqlCommand CreateCommand(Module module, SqlConnection connection, SqlTransaction transaction) => connection
            .CreateProcedureCommand(PROCEDURE, transaction)
            .AddInOutParameter(PARAM_ID, module.Id, SqlDbType.Int)
            .AddInParameter(PARAM_NAME, module.Name)
            .AddInParameter(PARAM_ORDINALNUMBER, module.OrdinalNumber)
            .AddInParameter(PARAM_APPLICATIONID, module.ApplicationId)
            .AddInParameter(PARAM_ROUTEURL, module.RouteUrl)
            .AddSessionIdParameter(_sessionIdProvider);
    }
}
