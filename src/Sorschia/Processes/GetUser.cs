using MediatR;
using System.Collections.Generic;

namespace Sorschia.Processes
{
    public class GetUser : IRequest<GetUser.Result>
    {
        public int Id { get; set; }
        public bool IncludeUserApplications { get; set; }
        public bool IncludeUserRoles { get; set; }
        public bool IncludeUserPermissions { get; set; }
        public UserApplication_OptionsObj? UserApplication { get; set; }
        public UserRole_OptionsObj? UserRole { get; set; }
        public UserPermission_OptionsObj? UserPermission { get; set; }

        public sealed class UserApplication_OptionsObj
        {
            public long? SkippedCount { get; set; }
            public int? TakenCount { get; set; }
            public ICollection<short> SkippedApplicationIds { get; set; } = new List<short>();
            public bool IncludeApplication { get; set; }
        }

        public sealed class UserRole_OptionsObj
        {
            public long? SkippedCount { get; set; }
            public int? TakenCount { get; set; }
            public ICollection<int> SkippedRoleIds { get; set; } = new List<int>();
            public bool IncludeRole { get; set; }
        }

        public sealed class UserPermission_OptionsObj
        {
            public long? SkippedCount { get; set; }
            public int? TakenCount { get; set; }
            public ICollection<int> SkippedPermissionIds { get; set; } = new List<int>();
            public bool IncludePermission { get; set; }
        }

        public sealed class UserApplicationObj
        {
            public long Id { get; set; }
            public short ApplicationId { get; set; }
            public ApplicationObj? Application { get; set; }
        }

        public sealed class ApplicationObj
        {
            public short Id { get; set; }
            public string Name { get; set; } = default!;
            public string? Description { get; set; }
        }

        public sealed class UserRoleObj
        {
            public long Id { get; set; }
            public int RoleId { get; set; }
            public RoleObj? Role { get; set; }
        }

        public sealed class RoleObj
        {
            public int Id { get; set; }
            public string Name { get; set; } = default!;
            public string? Description { get; set; }
        }

        public sealed class UserPermissionObj
        {
            public long Id { get; set; }
            public int PermissionId { get; set; }
            public PermissionObj? Permission { get; set; }
        }

        public sealed class PermissionObj
        {
            public int Id { get; set; }
            public string Name { get; set; } = default!;
            public string? Description { get; set; }
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
            public IEnumerable<UserApplicationObj>? UserApplications { get; set; }
            public IEnumerable<UserRoleObj>? UserRoles { get; set; }
            public IEnumerable<UserPermissionObj>? UserPermissions { get; set; }
        }
    }
}
