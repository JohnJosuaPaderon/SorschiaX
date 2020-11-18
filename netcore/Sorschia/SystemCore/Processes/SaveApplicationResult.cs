using Sorschia.SystemCore.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public sealed class SaveApplicationResult
    {
        public Application Application { get; set; }
        public IList<SaveModuleResult> Modules { get; set; }
        public IList<int> DeletedModuleIds { get; set; }
        public IList<ApplicationPermission> ApplicationPermissions { get; set; }
        public IList<long> DeletedApplicationPermissionIds { get; set; }
        public IList<UserApplication> UserApplications { get; set; }
        public IList<long> DeletedUserApplicationIds { get; set; }
    }
}
