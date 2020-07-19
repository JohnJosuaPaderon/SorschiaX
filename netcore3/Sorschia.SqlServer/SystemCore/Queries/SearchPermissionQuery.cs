using Sorschia.Data;
using Sorschia.Queries;
using Sorschia.SystemCore.Converters;
using Sorschia.SystemCore.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Queries
{
    internal sealed class SearchPermissionQuery : PaginationQueryBase
    {
        private const string PROCEDURE = "[SystemCore].[SearchPermission]";
        private const string PARAM_FILTERTEXT = "@FilterText";
        private const string PARAM_FILTERBYGROUP = "@FilterByGroup";
        private const string PARAM_GROUPIDS = "@GroupIds";
        private const string PARAM_SKIPPEDIDS = "@SkippedIds";
        private const string PARAM_ISAPIPERMISSION = "@IsApiPermission";
        private const string PARAM_ISDATABASEPERMISSION = "@IsDatabasePermission";

        private readonly PermissionConverter _converter;

        public SearchPermissionQuery(PermissionConverter converter)
        {
            _converter = converter;
        }

        public async Task ExecuteAsync(SearchPermissionModel model, SearchPermissionResult result, SqlConnection connection, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(model, connection);
            using var reader = await command.ExecuteReaderAsync(cancellationToken);

            if (reader.HasRows)
                while (await reader.ReadAsync(cancellationToken))
                    result.Permissions.Add(_converter.Convert(reader));

            await ReadTotalCountAsync(reader, result, cancellationToken);
        }

        private SqlCommand CreateCommand(SearchPermissionModel model, SqlConnection connection) => connection
            .CreateProcedureCommand(PROCEDURE)
            .AddPaginationParameters(model)
            .AddInParameter(PARAM_FILTERTEXT, model.FilterText)
            .AddInParameter(PARAM_FILTERBYGROUP, model.FilterByGroup)
            .AddIntListParameter(PARAM_GROUPIDS, model.GroupIds)
            .AddIntListParameter(PARAM_SKIPPEDIDS, model.SkippedIds)
            .AddInParameter(PARAM_ISAPIPERMISSION, model.IsApiPermission)
            .AddInParameter(PARAM_ISDATABASEPERMISSION, model.IsDatabasePermission);
    }
}
