using Sorschia.Data;
using Sorschia.SystemCore.Converters;
using Sorschia.SystemCore.Entities;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Queries
{
    internal sealed class GetSessionQuery
    {
        private const string PROCEDURE = "[SystemCore].[GetSession]";
        private const string PARAM_ID = "@Id";

        private readonly SessionConverter _converter;

        public GetSessionQuery(SessionConverter converter)
        {
            _converter = converter;
        }

        public async Task<Session> ExecuteAsync(long id, SqlConnection connection, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(id, connection);
            using var reader = await command.ExecuteReaderAsync(cancellationToken);
            if (reader.HasRows && await reader.ReadAsync(cancellationToken))
                return _converter.Convert(reader);
            return default;
        }

        private SqlCommand CreateCommand(long id, SqlConnection connection) => connection
            .CreateProcedureCommand(PROCEDURE)
            .AddInParameter(PARAM_ID, id);
    }
}
