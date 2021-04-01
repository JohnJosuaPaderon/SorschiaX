using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    internal sealed class SqlConnectionProvider
    {
        private readonly string _connectionString;

        public SqlConnectionProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<SqlConnection> OpenAsync(CancellationToken  cancellationToken = default)
        {
            var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync(cancellationToken);
            return connection;
        }
    }
}
