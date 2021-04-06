using Sorschia.Identity.Entities;
using System.Collections.Generic;

namespace Sorschia.Identity.Processes.Results
{
    public class InsertUserResult : UserBase
    {
        public IEnumerable<UserRoleObj> UserRoles { get; set; }
        public IEnumerable<UserPermissionObj> UserPermissions { get; set; }

        public class RoleObj : RoleBase
        {
        }

        public class UserRoleObj
        {
            public long Id { get; set; }
            public RoleObj Role { get; set; }
        }

        public class PermissionObj : PermissionBase
        {
        }

        public class UserPermissionObj
        {
            public long Id { get; set; }
            public PermissionObj Permissions { get; set; }
        }
    }
}
