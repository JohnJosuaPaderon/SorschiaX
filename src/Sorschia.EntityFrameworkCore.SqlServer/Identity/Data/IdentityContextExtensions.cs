using Sorschia.Identity.Entities;
using System.Threading;
using System.Threading.Tasks;
using SystemBase.Entities.Exceptions.Builders;

namespace Sorschia.Identity.Data
{
    internal static class IdentityContextExtensions
    {
        public static async Task<User> FindUserAsync(this IdentityContext instance, int id, CancellationToken cancellationToken = default)
        {
            if (id == 0)
                return null;

            var user = await instance.Users.FindAsync(new object[] { id }, cancellationToken);

            if (user is null)
                throw new EntityNotFoundExceptionBuilder()
                    .WithEntityType<User>()
                    .AddField(nameof(User.Id), id)
                    .WithMessage("User doesn't exists")
                    .WithDebugMessage($"User with Id '{id}' doesn't exists")
                    .Build();

            return user;
        }

        public static async Task<Role> FindRoleAsync(this IdentityContext instance, int id, CancellationToken cancellationToken = default)
        {
            if (id == 0)
                return null;

            var role = await instance.Roles.FindAsync(new object[] { id }, cancellationToken);

            if (role is null)
                throw new EntityNotFoundExceptionBuilder()
                    .WithEntityType<Role>()
                    .AddField(nameof(Role.Id), id) 
                    .WithMessage("Role doesn't exists")
                    .WithDebugMessage($"Role with Id '{id}' doesn't exists")
                    .Build();

            return role;
        }

        public static async Task<Permission> FindPermissionAsync(this IdentityContext instance, int id, CancellationToken cancellationToken = default)
        {
            if (id == 0)
                return null;

            var permission = await instance.Permissions.FindAsync(new object[] { id }, cancellationToken);

            if (permission is null)
                throw new EntityNotFoundExceptionBuilder()
                    .WithEntityType<Permission>()
                    .AddField(nameof(Permission.Id), id)
                    .WithMessage("Permission doesn't exists")
                    .WithDebugMessage($"Permission with Id '{id}' doesn't exists")
                    .Build();

            return permission;
        }
    }
}
