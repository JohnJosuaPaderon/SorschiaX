using Microsoft.EntityFrameworkCore;
using Sorschia.Extensions;
using Sorschia.Identity.Entities;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Identity.Data
{
    internal sealed class IdentityContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        public IdentityContext()
        {
        }

        public IdentityContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public async Task<User> FindUserAsync(int id, CancellationToken cancellationToken = default)
        {
            return await Users.FindByIdAsync(id, "User does not exists", $"Cannot find User with Id = {id}", cancellationToken);
        }

        public async Task<Role> FindRoleAsync(int id, CancellationToken cancellationToken = default)
        {
            return await Roles.FindByIdAsync(id, "Role does not exists", $"Cannot find Role with Id = {id}", cancellationToken);
        }

        public async Task<Permission> FindPermissionAsync(int id, CancellationToken cancellationToken = default)
        {
            return await Permissions.FindByIdAsync(id, "Permission does not exists", $"Cannot find Permission with Id = {id}", cancellationToken);
        }
    }
}
