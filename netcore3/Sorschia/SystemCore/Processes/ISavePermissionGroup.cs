using Sorschia.Processes;
using Sorschia.SystemCore.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public interface ISavePermissionGroup : IAsyncProcess<SavePermissionGroupResult>
    {
        SavePermissionGroupModel Model { get; set; }
    }

    public sealed class SavePermissionGroupModel
    {
        public PermissionGroup Group { get; set; }
        public IList<Permission> Permissions { get; set; } = new List<Permission>();
        public IList<DeletePermissionModel> DeletedPermissions { get; set; } = new List<DeletePermissionModel>();
        public IList<SavePermissionGroupModel> SubGroups { get; set; } = new List<SavePermissionGroupModel>();
        public IList<DeletePermissionGroupModel> DeletedSubGroups { get; set; } = new List<DeletePermissionGroupModel>();
    }

    public sealed class SavePermissionGroupResult
    {
        public PermissionGroup Group { get; set; }
        public IList<Permission> Permissions { get; set; } = new List<Permission>();
        public IList<int> DeletedPermissionIds { get; set; } = new List<int>();
        public IList<SavePermissionGroupResult> SubGroups { get; set; } = new List<SavePermissionGroupResult>();
        public IList<int> DeletedSubGroupIds { get; set; } = new List<int>();
    }
}
