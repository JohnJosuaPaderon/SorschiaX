using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia
{
    public abstract class SQLProcessBase : ProcessBase
    {
        public SQLProcessBase(string connectionString)
        {
            _connectionString = connectionString;
        }

        private readonly string _connectionString;

        private SqlConnection InitializeConnection()
        {
            return new SqlConnection(_connectionString);
        }

        protected SqlConnection OpenConnection()
        {
            var connection = InitializeConnection();
            connection.Open();
            return connection;
        }

        protected async Task<SqlConnection> OpenConnectionAsync(CancellationToken cancellationToken = default)
        {
            var connection = InitializeConnection();
            await connection.OpenAsync(cancellationToken);
            return connection;
        }

        protected void ThrowError(SqlException exception)
        {
            throw new SorschiaException(exception.Message, exception, exception.Number == 50_000);
        }
    }
}
