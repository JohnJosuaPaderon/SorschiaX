using Sorschia.SystemCore.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public sealed class SavePermissionResult
    {
        public Permission Permission { get; set; }
        public IList<ApplicationPermission> ApplicationPermissions { get; set; }
        public IList<long> DeletedApplicationPermissionIds { get; set; }
        public IList<ModulePermission> ModulePermissions { get; set; }
        public IList<long> DeletedModulePermissionIds { get; set; }
        public IList<RolePermission> RolePermissions { get; set; }
        public IList<long> DeletedRolePermissionIds { get; set; }
        public IList<UserPermission> UserPermissions { get; set; }
        public IList<long> DeletedUserPermissionIds { get; set; }
    }
}
