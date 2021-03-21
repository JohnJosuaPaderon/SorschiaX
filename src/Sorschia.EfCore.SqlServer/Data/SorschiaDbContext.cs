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
        public DbSet<User> Users { get; set; }
        public DbSet<UserApplication> UserApplications { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }

        public SorschiaDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new Application_ConfigObj())
                .ApplyConfiguration(new Role_ConfigObj())
                .ApplyConfiguration(new Permission_ConfigObj())
                .ApplyConfiguration(new PermissionAspNetRoute_ConfigObj())
                .ApplyConfiguration(new User_ConfigObj())
                .ApplyConfiguration(new UserApplication_ConfigObj())
                .ApplyConfiguration(new UserRole_ConfigObj())
                .ApplyConfiguration(new UserPermission_ConfigObj());

            base.OnModelCreating(modelBuilder);
        }
    }
}
