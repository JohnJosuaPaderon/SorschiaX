using Sorschia.Data;
using Sorschia.Queries;
using Sorschia.SystemCore.Converters;
using Sorschia.SystemCore.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Queries
{
    internal sealed class SearchPermissionGroupQuery : PaginationQueryBase
    {
        private const string PROCEDURE = "[SystemCore].[SearchPermissionGroup]";
        private const string PARAM_FILTERTEXT = "@FilterText";
        private const string PARAM_PARENTIDS = "@ParentIds";
        private const string PARAM_SKIPPEDIDS = "@SkippedIds";

        private readonly PermissionGroupConverter _converter;

        public SearchPermissionGroupQuery(PermissionGroupConverter converter)
        {
            _converter = converter;
        }

        public async Task ExecuteAsync(SearchPermissionGroupModel model, SearchPermissionGroupResult result, SqlConnection connection, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(model, connection);
            using var reader = await command.ExecuteReaderAsync(cancellationToken);

            if (reader.HasRows)
                while (await reader.ReadAsync(cancellationToken))
                    result.Groups.Add(_converter.Convert(reader));

            await ReadTotalCountAsync(reader, result, cancellationToken);
        }

        private SqlCommand CreateCommand(SearchPermissionGroupModel model, SqlConnection connection) => connection
            .CreateProcedureCommand(PROCEDURE)
            .AddPaginationParameters(model)
            .AddInParameter(PARAM_FILTERTEXT, model.FilterText)
            .AddIntValueParameter(PARAM_PARENTIDS, model.ParentIds)
            .AddIntValueParameter(PARAM_SKIPPEDIDS, model.SkippedIds);
    }
}
