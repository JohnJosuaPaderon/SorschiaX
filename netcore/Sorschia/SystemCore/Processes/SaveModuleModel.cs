using Sorschia.SystemCore.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public sealed class SaveModuleModel
    {
        public Module Module { get; set; }
        public IList<ModulePermission> ModulePermissions { get; set; }
        public IList<long> DeletedModulePermissionIds { get; set; }
        public IList<UserModule> UserModules { get; set; }
        public IList<long> DeletedUserModuleIds { get; set; }
    }
}
