using Microsoft.EntityFrameworkCore;
using Sorschia.Core.Entities;
using Sorschia.Data;
using Sorschia.Exceptions.Builders;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Core.Data
{
    internal sealed class CoreContext : SorschiaContext
    {
        public DbSet<Domain> Domains { get; set; }

        public CoreContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CoreContext).Assembly);
        }

        public async Task<Domain> FindDomainAsync(int id, CancellationToken cancellationToken = default)
        {
            if (id == 0)
                return null;

            var domain = await Domains.FindAsync(new object[] { id }, cancellationToken);

            if (domain is null)
                throw new EntityNotFoundExceptionBuilder()
                    .WithMessage("Domain does not exists")
                    .WithDebugMessage($"Domain with id = '{id}' does not exists")
                    .WithEntityType<Domain>()
                    .AddField(nameof(Domain.Id), id)
                    .Build();

            return domain;
        }
    }
}
