using Microsoft.EntityFrameworkCore;
using Sorschia.Core.Entities;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Core.Data
{
    internal sealed class CoreContext : DbContext
    {
        public DbSet<Domain> Domains { get; set; }

        public CoreContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public async Task<Domain> FindDomainAsync(int id, CancellationToken cancellationToken = default)
        {
            if (id == 0)
                return null;

            var domain = await Domains.FindAsync(new object[] { id }, cancellationToken);

            return domain;
        }
    }
}
