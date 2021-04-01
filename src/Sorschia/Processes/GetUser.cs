using MediatR;
using Sorschia.Processes.Results;
using System.Collections.Generic;

namespace Sorschia.Processes
{
    public class GetUser : IRequest<GetUserResult>
    {
        public int Id { get; set; }
        public bool IncludeUserApplications { get; set; }
        public UserApplicationObj? UserApplication { get; set; }
        public bool IncludeUserRoles { get; set; }
        public UserRoleObj? UserRole { get; set; }
        public bool IncludeUserPermissions { get; set; }
        public UserPermissionObj? UserPermission { get; set; }

        public class UserApplicationObj
        {
            public bool IncludeApplication { get; set; }
            public long? SkippedCount { get; set; }
            public int? TakenCount { get; set; }
            public IEnumerable<short>? SkippedApplicationIds { get; set; }
        }

        public class UserRoleObj
        {
            public bool IncludeRole { get; set; }
            public long? SkippedCount { get; set; }
            public int? TakenCount { get; set; }
            public IEnumerable<int>? SkippedRoleIds { get; set; }
        }

        public class UserPermissionObj
        {
            public bool IncludePermission { get; set; }
            public long? SkippedCount { get; set; }
            public int? TakenCount { get; set; }
            public IEnumerable<int>? SkippedPermissionIds { get; set; }
        }
    }
}
