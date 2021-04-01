using Sorschia.Entities;
using System.Collections.Generic;

namespace Sorschia.Processes.Results
{
    public class SaveUserResult : UserBase
    {
        public IEnumerable<UserApplicationObj>? UserApplications { get; set; }
        public IEnumerable<UserRoleObj>? UserRoles { get; set; }
        public IEnumerable<UserPermissionObj>? UserPermissions { get; set; }

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
            public ApplicationObj Application { get; set; } = default!;
        }

        public class UserRoleObj
        {
            public long Id { get; set; }
            public RoleObj Role { get; set; } = default!;
        }

        public class UserPermissionObj
        {
            public long Id { get; set; }
            public PermissionObj Permission { get; set; } = default!;
        }
    }
}
