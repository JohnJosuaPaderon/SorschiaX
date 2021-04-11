using Sorschia.Identity.Entities;

namespace Sorschia.Identity.Processes
{
    internal static class DbInsertUserPermissionExtensions
    {
        public static UserPermission AsUserPermission(this DbInsertUserPermission instance, User user = null, Permission permission = null)
        {
            if (instance is null)
                return null;

            return new UserPermission
            {
                UserId = instance.UserId,
                User = user,
                PermissionId = instance.PermissionId,
                Permission = permission
            };
        }

        public static DbInsertUserPermission Set(this DbInsertUserPermission instance, User user, int permissionId)
        {
            if (instance is not null && user is not null && permissionId != 0)
            {
                instance.User = user;
                instance.UserId = user.Id;
                instance.PermissionId = permissionId;
            }

            return instance;
        }
    }
}
