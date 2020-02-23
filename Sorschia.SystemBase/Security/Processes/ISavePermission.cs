using Sorschia.SystemBase.Security.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemBase.Security.Processes
{
    public interface ISavePermission : IAsyncProcess<SavePermissionResult>
    {
        SavePermissionModel Model { get; set; }
    }

    public sealed class SavePermissionModel
    {
        public SystemPermission Permission { get; set; }
        public IList<SystemUserPermission> UserPermissionList { get; set; } = new List<SystemUserPermission>();
        public IList<long> DeletedUserPermissionIdList { get; set; } = new List<long>();
    }

    public sealed class SavePermissionResult
    {
        public SystemPermission Permission { get; set; }
        public IList<SystemUserPermission> UserPermissionList { get; set; } = new List<SystemUserPermission>();
        public IList<long> DeletedUserPermissionIdList { get; set; } = new List<long>();
    }
}
