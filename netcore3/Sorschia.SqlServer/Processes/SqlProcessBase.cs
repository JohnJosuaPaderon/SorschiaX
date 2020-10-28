using Sorschia.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Processes
{
    public abstract class SqlProcessBase
    {
        protected abstract SqlConnection InitializeConnection();

        protected SqlConnection OpenConnection()
        {
            try
            {
                var connection = InitializeConnection();
                connection.Open();

                if (connection.State != ConnectionState.Open)
                    throw new SorschiaDataException("Database connection state is not open");

                return connection;
            }
            catch (Exception ex)
            {
                throw new SorschiaDataException("Cannot establish database connection", ex);
            }
        }

        protected async Task<SqlConnection> OpenConnectionAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var connection = InitializeConnection();
                await connection.OpenAsync(cancellationToken);

                if (connection.State != ConnectionState.Open)
                    throw new SorschiaDataException("Database connection state is not open");

                return connection;
            }
            catch (Exception ex)
            {
                throw new SorschiaDataException("Cannot establish database connection", ex);
            }
        }

        public virtual void Dispose()
        {
        }

        protected void ThrowError(Exception exception)
        {
            throw exception switch
            {
                SqlException sqlException => new SorschiaDataException(exception.Message, sqlException, sqlException.Number == 50_000),
                SorschiaException sorschiaException => sorschiaException,
                _ => new SorschiaException("An error occured", exception, true),
            };
        }
    }
}
