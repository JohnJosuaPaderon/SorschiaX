using Microsoft.EntityFrameworkCore;
using Sorschia.Auditing;
using Sorschia.Data;
using Sorschia.Identity.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Sorschia.Identity.Data
{
    internal sealed class IdentityContext : SorschiaDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }

        public IdentityContext([NotNull] DbContextOptions options, ICurrentFootprintProvider currentFootprintProvider) : base(options, currentFootprintProvider)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Identity")
                .ApplyConfigurationsFromAssembly(typeof(IdentityContext).Assembly);
        }
    }
}
