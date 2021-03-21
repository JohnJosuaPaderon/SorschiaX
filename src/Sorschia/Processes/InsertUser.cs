using MediatR;
using Sorschia.Utilities;
using System.Collections.Generic;

namespace Sorschia.Processes
{
    public class InsertUser : IRequest<InsertUser.Result>
    {
        public string FirstName { get; set; } = default!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = default!;
        public string? NameSuffix { get; set; }
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string? EmailAddress { get; set; }
        public string? MobileNumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsPasswordChangeRequired { get; set; }
        public bool IsEmailAddressVerified { get; set; }
        public bool IsMobileNumberVerified { get; set; }
        public ICollection<short> ApplicationIds { get; set; } = new List<short>();
        public ICollection<int> RoleIds { get; set; } = new List<int>();
        public ICollection<int> PermissionIds { get; set; } = new List<int>();

        public sealed class ApplicationObj
        {
            public short Id { get; set; }
            public string Name { get; set; } = default!;
            public string? Description { get; set; }
        }

        public sealed class RoleObj
        {
            public int Id { get; set; }
            public string Name { get; set; } = default!;
            public string? Description { get; set; }
        }

        public sealed class PermissionObj
        {
            public int Id { get; set; }
            public string Name { get; set; } = default!;
            public string? Description { get; set; }
        }

        public sealed class UserApplicationObj
        {
            public long Id { get; set; }
            public ApplicationObj Application { get; set; } = default!;
        }

        public sealed class UserRoleObj
        {
            public long Id { get; set; }
            public RoleObj Role { get; set; } = default!;
        }

        public sealed class UserPermissionObj
        {
            public long Id { get; set; }
            public PermissionObj Permission { get; set; } = default!;
        }

        public class Result
        {
            public int Id { get; set; }
            public string FirstName { get; set; } = default!;
            public string? MiddleName { get; set; }
            public string LastName { get; set; } = default!;
            public string? NameSuffix { get; set; }
            public string FullName { get; set; } = default!;
            public string Username { get; set; } = default!;
            public string? EmailAddress { get; set; }
            public string? MobileNumber { get; set; }
            public bool IsActive { get; set; }
            public bool IsPasswordChangeRequired { get; set; }
            public bool IsEmailAddressVerified { get; set; }
            public bool IsMobileNumberVerified { get; set; }
            public ICollection<UserApplicationObj> UserApplications { get; set; } = new List<UserApplicationObj>();
            public ICollection<UserRoleObj> UserRoles { get; set; } = new List<UserRoleObj>();
            public ICollection<UserPermissionObj> UserPermissions { get; set; } = new List<UserPermissionObj>(); 
        }
    }
}
