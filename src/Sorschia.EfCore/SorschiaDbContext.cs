using Microsoft.EntityFrameworkCore;
using Sorschia.ChangeTracking;
using Sorschia.Configuration;
using Sorschia.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia
{
    internal sealed class SorschiaDbContext : DbContext
    {
        public DbSet<Application> Applications { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserApplication> UserApplications { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder
                .ApplyConfiguration(new ApplicationConfiguration())
                .ApplyConfiguration(new PermissionConfiguration())
                .ApplyConfiguration(new UserApplicationConfiguration())
                .ApplyConfiguration(new UserConfiguration())
                .ApplyConfiguration(new UserPermissionConfiguration());
        }

        private void OnSaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                entry
                    .ConfigureEntityBaseFields();
            }
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnSaveChanges();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnSaveChanges();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
