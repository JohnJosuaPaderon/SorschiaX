using Sorschia.Data;
using Sorschia.SystemCore.Converters;
using Sorschia.SystemCore.Entities;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Queries
{
    internal sealed class GetApplicationQuery
    {
        private const string PROCEDURE = "[SystemCore].[GetApplication]";
        private const string PARAM_ID = "@Id";

        private readonly ApplicationConverter _converter;

        public GetApplicationQuery(ApplicationConverter converter)
        {
            _converter = converter;
        }

        public async Task<Application> ExecuteAsync(int id, SqlConnection connection, SqlTransaction transaction = default, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(id, connection, transaction);
            using var reader = await command.ExecuteReaderAsync(cancellationToken);
            if (reader.HasRows && await reader.ReadAsync(cancellationToken))
                return _converter.Convert(reader);
            return default;
        }

        private SqlCommand CreateCommand(int id, SqlConnection connection, SqlTransaction transaction) => connection
            .CreateProcedureCommand(PROCEDURE, transaction)
            .AddInParameter(PARAM_ID, id);
    }
}
