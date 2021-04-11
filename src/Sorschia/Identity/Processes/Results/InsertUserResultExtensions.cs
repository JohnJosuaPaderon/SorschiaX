using Sorschia.Identity.Entities;

namespace Sorschia.Identity.Processes.Results
{
    public static class InsertUserResultExtensions
    {
        public static InsertUserResult Set(this InsertUserResult instance, User user)
        {
            if (instance is not null && user is not null)
            {
                instance.Id = user.Id;
                instance.FirstName = user.FirstName;
                instance.MiddleName = user.MiddleName;
                instance.LastName = user.LastName;
                instance.NameSuffix = user.NameSuffix;
                instance.FullName = user.FullName;
                instance.Username = user.Username;
                instance.Status = user.Status;
                instance.IsPasswordChangeRequired = user.IsPasswordChangeRequired;
            }

            return instance;
        }

        public static InsertUserResult.UserRoleObj Set(this InsertUserResult.UserRoleObj instance, long userRoleId, Role role)
        {
            if (instance is not null && role is not null)
            {
                instance.Id = userRoleId;
                instance.Role = role;
            }

            return instance;
        }

        public static InsertUserResult.UserPermissionObj Set(this InsertUserResult.UserPermissionObj instance, long userPermissionId, Permission permission)
        {
            if (instance is not null && permission is not null)
            {
                instance.Id = userPermissionId;
                instance.Permission = permission;
            }

            return instance;
        }
    }
}
