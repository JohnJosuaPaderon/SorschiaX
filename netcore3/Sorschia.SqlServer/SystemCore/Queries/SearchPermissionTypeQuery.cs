using Sorschia.Data;
using Sorschia.Queries;
using Sorschia.SystemCore.Converters;
using Sorschia.SystemCore.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Queries
{
    internal sealed class SearchPermissionTypeQuery : PaginationQueryBase
    {
        private const string PROCEDURE = "[SystemCore].[SearchPermissionType]";
        private const string PARAM_FILTERTEXT = "@FilterText";
        private const string PARAM_SKIPPEDIDS = "@SkippedIds";

        private readonly PermissionTypeConverter _converter;

        public SearchPermissionTypeQuery(PermissionTypeConverter converter)
        {
            _converter = converter;
        }

        public async Task ExecuteAsync(SearchPermissionTypeModel model, SearchPermissionTypeResult result, SqlConnection connection, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(model, connection);
            using var reader = await command.ExecuteReaderAsync(cancellationToken);

            if (reader.HasRows)
                while (await reader.ReadAsync(cancellationToken))
                    result.Types.Add(_converter.Convert(reader));

            await ReadTotalCountAsync(reader, result, cancellationToken);
        }

        private SqlCommand CreateCommand(SearchPermissionTypeModel model, SqlConnection connection) => connection
            .CreateProcedureCommand(PROCEDURE)
            .AddPaginationParameters(model)
            .AddInParameter(PARAM_FILTERTEXT, model.FilterText)
            .AddIntListParameter(PARAM_SKIPPEDIDS, model.SkippedIds);
    }
}
