using Sorschia.SystemCore.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public sealed class SaveUserModel
    {
        public User User { get; set; }
        public IList<UserApplication> UserApplications { get; set; }
        public IList<long> DeletedUserApplicationIds { get; set; }
        public IList<UserModule> UserModules { get; set; }
        public IList<long> DeletedUserModuleIds { get; set; }
        public IList<UserPermission> UserPermissions { get; set; }
        public IList<long> DeletedUserPermissionIds { get; set; }
        public IList<UserRole> UserRoles { get; set; }
        public IList<long> DeletedUserRoleIds { get; set; }
    }
}
