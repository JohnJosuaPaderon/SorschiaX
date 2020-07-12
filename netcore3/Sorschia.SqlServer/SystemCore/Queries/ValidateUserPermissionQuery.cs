using Sorschia.Data;
using Sorschia.SystemCore.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Queries
{
    internal sealed class ValidateUserPermissionQuery
    {
        private const string FUNCTION = "[SystemCore].[ValidateUserPermission]";
        private const string PARAM_USERID = "@UserId";
        private const string PARAM_PERMISSIONID = "@PermissionId";

        public async Task<bool> ExecuteAsync(ValidateUserPermissionModel model, SqlConnection connection, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(model, connection);
            return DbValueConverter.ToBoolean(await command.ExecuteScalarAsync(cancellationToken));
        }

        private SqlCommand CreateCommand(ValidateUserPermissionModel model, SqlConnection connection) => connection
            .CreateCommand($"SELECT {FUNCTION}({PARAM_USERID}, {PARAM_PERMISSIONID});")
            .AddInParameter(PARAM_USERID, model.UserId)
            .AddInParameter(PARAM_PERMISSIONID, model.PermissionId);
    }

}
