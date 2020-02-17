using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Process
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
    }
}
