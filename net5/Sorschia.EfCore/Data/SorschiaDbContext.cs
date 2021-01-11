using Microsoft.EntityFrameworkCore;
using Sorschia.Entities;
using Sorschia.EntityConfigurations;

namespace Sorschia.Data
{
    public sealed class SorschiaDbContext : DbContext
    {
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new PermissionConfiguration())
                .ApplyConfiguration(new UserConfiguration())
                .ApplyConfiguration(new UserPermissionConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
