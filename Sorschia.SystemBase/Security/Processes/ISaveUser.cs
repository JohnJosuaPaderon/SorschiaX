using Sorschia.SystemBase.Security.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemBase.Security.Processes
{
    public interface ISaveUser : IAsyncProcess<SaveUserResult>
    {
        SaveUserModel Model { get; set; }
    }

    public sealed class SaveUserModel
    {
        public SystemUser User { get; set; }
        public IList<SystemUserApplication> UserApplicationList { get; set; } = new List<SystemUserApplication>();
        public IList<SystemUserModule> UserModuleList { get; set; } = new List<SystemUserModule>();
        public IList<SystemUserPermission> UserPermissionList { get; set; } = new List<SystemUserPermission>();
        public IList<long> DeletedUserApplicationIdList { get; set; } = new List<long>();
        public IList<long> DeletedUserModuleIdList { get; set; } = new List<long>();
        public IList<long> DeletedUserPermissionIdList { get; set; } = new List<long>();
    }

    public sealed class SaveUserResult
    {
        public SystemUser User { get; set; }
        public IList<SystemUserApplication> UserApplicationList { get; set; } = new List<SystemUserApplication>();
        public IList<SystemUserModule> UserModuleList { get; set; } = new List<SystemUserModule>();
        public IList<SystemUserPermission> UserPermissionList { get; set; } = new List<SystemUserPermission>();
        public IList<long> DeletedUserApplicationIdList { get; set; } = new List<long>();
        public IList<long> DeletedUserModuleIdList { get; set; } = new List<long>();
        public IList<long> DeletedUserPermissionIdList { get; set; } = new List<long>();
    }
}
