using Sorschia.Identity.Data;

namespace Sorschia.Identity.Processes
{
    internal static class InsertPermissionExtensions
    {
        public static DbInsertPermission AsDbInsertPermission(this InsertPermission instance, IdentityContext context)
        {
            if (instance is null)
                return null;

            return new DbInsertPermission(context)
            {
                RoleId = instance.RoleId,
                LookupCode = instance.LookupCode,
                Name = instance.Name,
                Description = instance.Description
            };
        }
    }
}
