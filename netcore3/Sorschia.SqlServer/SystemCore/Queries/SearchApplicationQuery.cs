using Sorschia.Data;
using Sorschia.Queries;
using Sorschia.SystemCore.Converters;
using Sorschia.SystemCore.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Queries
{
    internal sealed class SearchApplicationQuery : PaginationQueryBase
    {
        private const string PROCEDURE = "[SystemCore].[SearchApplication]";
        private const string PARAM_FILTERTEXT = "@FilterText";
        private const string PARAM_PLATFORMIDS = "@PlatformIds";
        private const string PARAM_SKIPPEDIDS = "@SkippedIds";
        private const string PARAM_USERIDS = "@UserIds";

        private readonly ApplicationConverter _converter;

        public SearchApplicationQuery(ApplicationConverter converter)
        {
            _converter = converter;
        }

        public async Task ExecuteAsync(SearchApplicationModel model, SearchApplicationResult result, SqlConnection connection, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(model, connection);
            using var reader = await command.ExecuteReaderAsync(cancellationToken);

            if (reader.HasRows)
                while (await reader.ReadAsync(cancellationToken))
                    result.Applications.Add(_converter.Convert(reader));

            await ReadTotalCountAsync(reader, result, cancellationToken);
        }

        private SqlCommand CreateCommand(SearchApplicationModel model, SqlConnection connection) => connection
            .CreateProcedureCommand(PROCEDURE)
            .AddPaginationParameters(model)
            .AddInParameter(PARAM_FILTERTEXT, model.FilterText)
            .AddIntValueParameter(PARAM_PLATFORMIDS, model.PlatformIds)
            .AddIntValueParameter(PARAM_SKIPPEDIDS, model.SkippedIds)
            .AddIntValueParameter(PARAM_USERIDS, model.UserIds);
    }
}
