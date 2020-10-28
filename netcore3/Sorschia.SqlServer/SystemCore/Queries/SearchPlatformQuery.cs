using Sorschia.Data;
using Sorschia.Queries;
using Sorschia.SystemCore.Converters;
using Sorschia.SystemCore.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Queries
{
    internal sealed class SearchPlatformQuery : PaginationQueryBase
    {
        private const string PROCEDURE = "[SystemCore].[SearchPlatform]";
        private const string PARAM_FILTERTEXT = "@FilterText";
        private const string PARAM_SKIPPEDIDS = "@SkippedIds";

        private readonly PlatformConverter _converter;

        public SearchPlatformQuery(PlatformConverter converter)
        {
            _converter = converter;
        }

        public async Task ExecuteAsync(SearchPlatformModel model, SearchPlatformResult result, SqlConnection connection, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(model, connection);
            using var reader = await command.ExecuteReaderAsync(cancellationToken);

            if (reader.HasRows)
                while (await reader.ReadAsync(cancellationToken))
                    result.Platforms.Add(_converter.Convert(reader));

            await ReadTotalCountAsync(reader, result, cancellationToken);
        }

        private SqlCommand CreateCommand(SearchPlatformModel model, SqlConnection connection) => connection
            .CreateProcedureCommand(PROCEDURE)
            .AddPaginationParameters(model)
            .AddInParameter(PARAM_FILTERTEXT, model.FilterText)
            .AddIntValueParameter(PARAM_SKIPPEDIDS, model.SkippedIds);
    }
}
