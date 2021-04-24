using Microsoft.EntityFrameworkCore;
using Sorschia.Identity.Entities;
using System.Diagnostics.CodeAnalysis;
using SystemBase.Data;

namespace Sorschia.Identity.Data
{
    internal sealed class IdentityContext : SystemBaseDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }

        public IdentityContext([NotNull] DbContextOptions options) : base(options)
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
