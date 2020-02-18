using Sorschia.Process;
using Sorschia.SystemBase.Security.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemBase.Security.Processes
{
    public interface ISaveSystemPermission : IAsyncProcess<SaveSystemPermissionResult>
    {
        SaveSystemPermissionModel Model { get; set; }
    }

    public sealed class SaveSystemPermissionModel
    {
        public SystemPermission Permission { get; set; }
        public IList<SystemUserPermission> UserPermissionList { get; set; } = new List<SystemUserPermission>();
        public IList<SystemUserPermission> DeletedUserPermissionList { get; set; } = new List<SystemUserPermission>();
    }

    public sealed class SaveSystemPermissionResult
    {
        public SystemPermission Permission { get; set; }
        public IList<SystemUserPermission> UserPermissionList { get; set; } = new List<SystemUserPermission>();
        public IList<SystemUserPermission> DeletedUserPermissionList { get; set; } = new List<SystemUserPermission>();
    }
}
