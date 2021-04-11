using Sorschia.Identity.Data;

namespace Sorschia.Identity.Processes
{
    internal static class InsertRoleExtensions
    {
        public static DbInsertRole AsDbInsertRole(this InsertRole instance, IdentityContext context)
        {
            if (instance is null)
                return null;

            return new DbInsertRole(context)
            {
                LookupCode = instance.LookupCode,
                Name = instance.Name,
                Description = instance.Description
            };
        }
    }
}
