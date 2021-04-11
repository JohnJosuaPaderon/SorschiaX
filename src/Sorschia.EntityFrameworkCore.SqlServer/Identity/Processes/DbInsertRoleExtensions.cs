using Sorschia.Identity.Entities;

namespace Sorschia.Identity.Processes
{
    internal static class DbInsertRoleExtensions
    {
        public static Role AsRole(this DbInsertRole instance)
        {
            if (instance is null)
                return null;

            return new Role
            {
                LookupCode = instance.LookupCode,
                Name = instance.Name,
                Description = instance.Description
            };
        }
    }
}
