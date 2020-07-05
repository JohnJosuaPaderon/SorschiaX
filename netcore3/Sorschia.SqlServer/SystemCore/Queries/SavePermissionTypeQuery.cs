using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Queries
{
    internal sealed class SavePermissionTypeQuery
    {
        private const string PROCEDURE = "[SystemCore].[SavePermissionType]";
        private const string PARAM_ID = "@Id";
        private const string PARAM_NAME = "@Name";
        private const int AFFECTEDROWS = 1;

        private readonly ISessionProvider _sessionProvider;

        public SavePermissionTypeQuery(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        public async Task<PermissionType> ExecuteAsync(PermissionType module, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(module, connection, transaction);

            if (await command.ExecuteNonQueryAsync(cancellationToken) == AFFECTEDROWS)
            {
                module.Id = command.Parameters.GetInt32(PARAM_ID);
                return module;
            }

            return null;
        }

        private SqlCommand CreateCommand(PermissionType type, SqlConnection connection, SqlTransaction transaction) => connection
            .CreateProcedureCommand(PROCEDURE, transaction)
            .AddInOutParameter(PARAM_ID, type.Id, SqlDbType.Int)
            .AddInParameter(PARAM_NAME, type.Name)
            .AddSessionIdParameter(_sessionProvider);
    }
}
