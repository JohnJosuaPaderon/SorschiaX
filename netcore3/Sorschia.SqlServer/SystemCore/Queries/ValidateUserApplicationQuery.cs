using Sorschia.Data;
using Sorschia.SystemCore.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Queries
{
    internal sealed class ValidateUserApplicationQuery
    {
        private const string FUNCTION = "[SystemCore].[ValidateUserApplication]";
        private const string PARAM_USERID = "@UserId";
        private const string PARAM_APPLICATIONID = "@ApplicationId";

        public async Task<bool> ExecuteAsync(ValidateUserApplicationModel model, SqlConnection connection, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(model, connection);
            return DbValueConverter.ToBoolean(await command.ExecuteScalarAsync(cancellationToken));
        }

        private SqlCommand CreateCommand(ValidateUserApplicationModel model, SqlConnection connection) => connection
            .CreateCommand($"SELECT {FUNCTION}({PARAM_USERID}, {PARAM_APPLICATIONID});")
            .AddInParameter(PARAM_USERID, model.UserId)
            .AddInParameter(PARAM_APPLICATIONID, model.ApplicationId);
    }

}
