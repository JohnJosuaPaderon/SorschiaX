using Sorschia.SystemCore.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public sealed class SaveRoleResult
    {
        public Role Role { get; set; }
        public IList<RolePermission> RolePermissions { get; set; }
        public IList<long> DeletedRolePermissionIds { get; set; }
        public IList<UserRole> UserRoles { get; set; }
        public IList<long> DeletedUserRoleIds { get; set; }
    }
}
