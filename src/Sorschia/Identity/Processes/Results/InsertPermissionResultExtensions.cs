using Sorschia.Identity.Entities;

namespace Sorschia.Identity.Processes.Results
{
    public static class InsertPermissionResultExtensions
    {
        public static InsertPermissionResult Set(this InsertPermissionResult instance, Permission permission)
        {
            if (instance is not null && permission is not null)
            {
                instance.Id = permission.Id;
                instance.RoleId = permission.RoleId;
                instance.Role = permission.Role;
                instance.LookupCode = permission.LookupCode;
                instance.Name = permission.Name;
                instance.Description = permission.Description;
            }

            return instance;
        }
    }
}
