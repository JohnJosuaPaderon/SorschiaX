using System.Collections.Generic;

namespace Sorschia.Processes
{
    public interface IInsertUser : IAsyncProcess<InsertUserInput, InsertUserOutput>
    {
    }

    public sealed class InsertUserInput
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsPasswordChangeRequired { get; set; }
        public bool IsEmailAddressVerified { get; set; }
        public bool IsMobileNumberVerified { get; set; }
        public IList<short> ApplicationIds { get; set; }
        public IList<int> RoleIds { get; set; }
        public IList<int> PermissionIds { get; set; }
    }

    public sealed class InsertUserOutput
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NameSuffix { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsPasswordChangeRequired { get; set; }
        public bool IsEmailAddressVerified { get; set; }
        public bool IsMobileNumberVerified { get; set; }
        public IList<UserApplicationObj> UserApplications { get; set; }
        public IList<UserRoleObj> UserRoles { get; set; }
        public IList<UserPermissionObj> UserPermissions { get; set; }

        public sealed class ApplicationObj
        {
            public short Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public sealed class RoleObj
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public sealed class PermissionObj
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public sealed class UserApplicationObj
        {
            public long Id { get; set; }
            public ApplicationObj Application { get; set; }
        }

        public sealed class UserRoleObj
        {
            public long Id { get; set; }
            public RoleObj Role { get; set; }
        }

        public sealed class UserPermissionObj
        {
            public long Id { get; set; }
            public PermissionObj Permission { get; set; }
        }
    }
}
