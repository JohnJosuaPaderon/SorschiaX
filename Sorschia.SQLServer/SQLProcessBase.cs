using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia
{
    public abstract class SqlProcessBase : ProcessBase
    {
        public SqlProcessBase(string connectionString)
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

        protected void ThrowError(Exception exception)
        {
            throw exception switch
            {
                SqlException sqlException => new SorschiaException(exception.Message, sqlException, sqlException.Number == 50_000),
                _ => new SorschiaException("An error occured", exception, true),
            };
        }
    }
}
