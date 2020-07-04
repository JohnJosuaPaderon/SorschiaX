using Sorschia.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Queries
{
    public abstract class PaginationQueryBase
    {
        protected async Task ReadTotalCountAsync(SqlDataReader reader, PaginationResult result, CancellationToken cancellationToken = default) =>
            result.TotalCount = await reader.NextResultAsync(cancellationToken) && await reader.ReadAsync(cancellationToken) ? reader.GetInt32(0) : default;
    }
}
