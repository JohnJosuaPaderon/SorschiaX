using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    internal sealed class SqlConnectionProvider
    {
        private readonly IConfiguration _configuration;

        public SqlConnectionProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<SqlConnection> OpenAsync(string configKey, CancellationToken  cancellationToken = default)
        {
            var connection = new SqlConnection(_configuration.GetConnectionString(configKey));
            await connection.OpenAsync(cancellationToken);
            return connection;
        }

        public async Task<SqlConnection> OpenAsync(CancellationToken cancellationToken = default)
        {
            return await OpenAsync("Default", cancellationToken);
        }
    }
}
