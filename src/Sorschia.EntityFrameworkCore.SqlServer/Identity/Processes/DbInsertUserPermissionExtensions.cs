using Sorschia.Identity.Entities;

namespace Sorschia.Identity.Processes
{
    internal static class DbInsertUserPermissionExtensions
    {
        public static UserPermission AsUserPermission(this DbInsertUserPermission instance)
        {
            if (instance is null)
                return null;

            return new UserPermission
            {
                UserId = instance.UserId,
                PermissionId = instance.PermissionId
            };
        }
    }
}
