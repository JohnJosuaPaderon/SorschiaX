using Microsoft.EntityFrameworkCore;
using Sorschia.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Processes
{
    internal sealed class InsertApplication : IInsertApplication
    {
        private readonly IDbContextFactory<SorschiaDbContext> _contextFactory;

        public InsertApplication(IDbContextFactory<SorschiaDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<InsertApplicationOutput> ExecuteAsync(InsertApplicationInput input, CancellationToken cancellationToken = default)
        {
            using var context = _contextFactory.CreateDbContext();
            var output = new InsertApplicationOutput();
            return output;
        }
    }
}
