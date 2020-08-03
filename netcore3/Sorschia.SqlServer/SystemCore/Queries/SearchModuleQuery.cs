using Sorschia.Data;
using Sorschia.Queries;
using Sorschia.SystemCore.Converters;
using Sorschia.SystemCore.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Queries
{
    internal sealed class SearchModuleQuery : PaginationQueryBase
    {
        private const string PROCEDURE = "[SystemCore].[SearchModule]";
        private const string PARAM_FILTERTEXT = "@FilterText";
        private const string PARAM_FILTERBYAPPLICATION = "@FilterByApplication";
        private const string PARAM_APPLICATIONIDS = "@ApplicationIds";
        private const string PARAM_SKIPPEDIDS = "@SkippedIds";

        private readonly ModuleConverter _converter;

        public SearchModuleQuery(ModuleConverter converter)
        {
            _converter = converter;
        }

        public async Task ExecuteAsync(SearchModuleModel model, SearchModuleResult result, SqlConnection connection, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(model, connection);
            using var reader = await command.ExecuteReaderAsync(cancellationToken);

            if (reader.HasRows)
                while (await reader.ReadAsync(cancellationToken))
                    result.Modules.Add(_converter.Convert(reader));

            await ReadTotalCountAsync(reader, result, cancellationToken);
        }

        private SqlCommand CreateCommand(SearchModuleModel model, SqlConnection connection) => connection
            .CreateProcedureCommand(PROCEDURE)
            .AddPaginationParameters(model)
            .AddInParameter(PARAM_FILTERTEXT, model.FilterText)
            .AddInParameter(PARAM_FILTERBYAPPLICATION, model.FilterByApplication)
            .AddIntsParameter(PARAM_APPLICATIONIDS, model.ApplicationIds)
            .AddIntsParameter(PARAM_SKIPPEDIDS, model.SkippedIds);
    }
}
