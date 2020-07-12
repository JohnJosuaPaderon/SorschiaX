using Sorschia.Data;
using Sorschia.SystemCore.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Queries
{
    internal sealed class ValidateUserModuleQuery
    {
        private const string FUNCTION = "[SystemCore].[ValidateUserModule]";
        private const string PARAM_USERID = "@UserId";
        private const string PARAM_MODULEID = "@ModuleId";

        public async Task<bool> ExecuteAsync(ValidateUserModuleModel model, SqlConnection connection, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(model, connection);
            return DbValueConverter.ToBoolean(await command.ExecuteScalarAsync(cancellationToken));
        }

        private SqlCommand CreateCommand(ValidateUserModuleModel model, SqlConnection connection) => connection
            .CreateCommand($"SELECT {FUNCTION}({PARAM_USERID}, {PARAM_MODULEID});")
            .AddInParameter(PARAM_USERID, model.UserId)
            .AddInParameter(PARAM_MODULEID, model.ModuleId);
    }

}
