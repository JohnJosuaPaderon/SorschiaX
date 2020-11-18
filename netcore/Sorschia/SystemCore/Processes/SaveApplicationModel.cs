using Sorschia.SystemCore.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public sealed class SaveApplicationModel
    {
        public Application Application { get; set; }
        public IList<SaveModuleModel> Modules { get; set; }
        public IList<DeleteModuleModel> DeletedModules { get; set; }
        public IList<ApplicationPermission> ApplicationPermissions { get; set; }
        public IList<long> DeletedApplicationPermissionIds { get; set; }
        public IList<UserApplication> UserApplications { get; set; }
        public IList<long> DeletedUserApplicationIds { get; set; }
    }
}
