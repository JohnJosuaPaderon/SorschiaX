using Microsoft.EntityFrameworkCore;
using Sorschia.Entities;

namespace Sorschia.Data
{
    internal sealed partial class SorschiaDbContext : DbContext
    {
        private readonly DataOptions _dataOptions;

        public DbSet<Application> Applications { get; set; }
        public DbSet<Permission> Permisions { get; set; }
        public DbSet<PermissionAspNetRoute> PermissionAspNetRoutes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public SorschiaDbContext(DbContextOptions contextOptions, DataOptions dataOptions) : base(contextOptions)
        {
            _dataOptions = dataOptions;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new Application_ConfigObj(_dataOptions.Application))
                .ApplyConfiguration(new Permission_ConfigObj(_dataOptions.Permission))
                .ApplyConfiguration(new PermissionAspNetRoute_ConfigObj(_dataOptions.PermissionAspNetRoute))
                .ApplyConfiguration(new Role_ConfigObj(_dataOptions.Role))
                .ApplyConfiguration(new User_ConfigObj(_dataOptions.User));
        }
    }
}
