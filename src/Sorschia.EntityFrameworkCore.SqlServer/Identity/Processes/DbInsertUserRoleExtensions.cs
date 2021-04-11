using Sorschia.Identity.Entities;

namespace Sorschia.Identity.Processes
{
    internal static class DbInsertUserRoleExtensions
    {
        public static UserRole AsUserRole(this DbInsertUserRole instance)
        {
            if (instance is null)
                return null;

            return new UserRole
            {
                UserId = instance.UserId,
                RoleId = instance.RoleId
            };
        }
    }
}
