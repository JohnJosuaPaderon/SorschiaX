using Sorschia.Entities;
using System.Collections.Generic;

namespace Sorschia.Processes.Results
{
    public class GetUserResult : UserBase
    {
        public IEnumerable<UserApplicationObj>? UserApplications { get; set; }
        public long UserApplicationsTotalCount { get; set; }
        public IEnumerable<UserRoleObj>? UserRoles { get; set; }
        public long UserRolesTotalCount { get; set; }
        public IEnumerable<UserPermissionObj>? UserPermissions { get; set; }
        public long UserPermissionsTotalCount { get; set; }

        public class ApplicationObj : ApplicationBase
        {
        }

        public class RoleObj : RoleBase
        {
        }

        public class PermissionObj : PermissionBase
        {
        }

        public class UserApplicationObj
        {
            public long Id { get; set; }
            public short ApplicationId { get; set; }
            public ApplicationObj? Application { get; set; }
        }

        public class UserRoleObj
        {
            public long Id { get; set; }
            public int RoleId { get; set; }
            public RoleObj? Role { get; set; }
        }

        public class UserPermissionObj
        {
            public long Id { get; set; }
            public int PermissionId { get; set; }
            public PermissionObj? Permission { get; set; }
        }
    }
}
