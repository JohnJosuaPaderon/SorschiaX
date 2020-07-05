using Sorschia.Processes;
using Sorschia.SystemCore.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public interface ISavePermission : IAsyncProcess<SavePermissionResult>
    {
        SavePermissionModel Model { get; set; }
    }

    public abstract class SavePermissionModelBase
    {
        public IList<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();
        public IList<DeleteUserPermissionModel> DeletedUserPermissions { get; set; } = new List<DeleteUserPermissionModel>();
    }

    public abstract class SavePermissionResultBase
    {
        public IList<UserPermission> UserPermissions { get; set; } = new List<UserPermission>();
        public IList<long> DeletedUserPermissionIds { get; set; } = new List<long>();
    }

    public sealed class SavePermissionModel : SavePermissionModelBase
    {
        public Permission Permission { get; set; }
    }

    public sealed class SavePermissionResult : SavePermissionResultBase
    {
        public Permission Permission { get; set; }
    }
}
