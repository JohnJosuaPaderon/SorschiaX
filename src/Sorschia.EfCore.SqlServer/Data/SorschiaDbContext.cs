using Microsoft.EntityFrameworkCore;
using Sorschia.Entities;

namespace Sorschia.Data
{
    internal sealed partial class SorschiaDbContext : DbContext
    {
        public DbSet<Application> Applications { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionAspNetRoute> PermissionAspNetRoutes { get; set; }

        public SorschiaDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new Application_ConfigObj())
                .ApplyConfiguration(new Role_ConfigObj())
                .ApplyConfiguration(new Permission_ConfigObj())
                .ApplyConfiguration(new PermissionAspNetRoute_ConfigObj());

            base.OnModelCreating(modelBuilder);
        }
    }
}
