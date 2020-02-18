using Sorschia.Process;
using Sorschia.SystemBase.Security.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemBase.Security.Processes
{
    public interface ISaveSystemUser : IAsyncProcess<SaveSystemUserResult>
    {
        SaveSystemUserModel Model { get; set; }
    }

    public sealed class SaveSystemUserModel
    {
        public SystemUser User { get; set; }
        public IList<SystemUserApplication> UserApplicationList { get; set; } = new List<SystemUserApplication>();
        public IList<SystemUserModule> UserModuleList { get; set; } = new List<SystemUserModule>();
        public IList<SystemUserPermission> UserPermissionList { get; set; } = new List<SystemUserPermission>();
        public IList<SystemUserApplication> DeletedUserApplicationList { get; set; } = new List<SystemUserApplication>();
        public IList<SystemUserModule> DeletedUserModuleList { get; set; } = new List<SystemUserModule>();
        public IList<SystemUserPermission> DeletedUserPermissionList { get; set; } = new List<SystemUserPermission>();
    }

    public sealed class SaveSystemUserResult
    {
        public SystemUser User { get; set; }
        public IList<SystemUserApplication> UserApplicationList { get; set; } = new List<SystemUserApplication>();
        public IList<SystemUserModule> UserModuleList { get; set; } = new List<SystemUserModule>();
        public IList<SystemUserPermission> UserPermissionList { get; set; } = new List<SystemUserPermission>();
        public IList<SystemUserApplication> DeletedUserApplicationList { get; set; } = new List<SystemUserApplication>();
        public IList<SystemUserModule> DeletedUserModuleList { get; set; } = new List<SystemUserModule>();
        public IList<SystemUserPermission> DeletedUserPermissionList { get; set; } = new List<SystemUserPermission>();
    }
}
