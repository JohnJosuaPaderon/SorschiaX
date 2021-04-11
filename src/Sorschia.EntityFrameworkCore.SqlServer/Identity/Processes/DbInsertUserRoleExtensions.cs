using Sorschia.Identity.Entities;

namespace Sorschia.Identity.Processes
{
    internal static class DbInsertUserRoleExtensions
    {
        public static UserRole AsUserRole(this DbInsertUserRole instance, User user = null, Role role = null)
        {
            if (instance is null)
                return null;

            return new UserRole
            {
                UserId = instance.UserId,
                RoleId = instance.RoleId,
                User = user,
                Role = role
            };
        }

        public static DbInsertUserRole Set(this DbInsertUserRole instance, User user, int roleId)
        {
            if (instance is not null && user is not null && roleId != 0)
            {
                instance.User = user;
                instance.UserId = user.Id;
                instance.RoleId = roleId;
            }

            return instance;
        }
    }
}
