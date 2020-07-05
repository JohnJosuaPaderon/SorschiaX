using Sorschia.Processes;
using Sorschia.SystemCore.Entities;

namespace Sorschia.SystemCore.Processes
{
    public interface ISavePermissionType : IAsyncProcess<SavePermissionTypeResult>
    {
        SavePermissionTypeModel Model { get; set; }
    }

    public sealed class SavePermissionTypeModel
    {
        public PermissionType Type { get; set; }
    }

    public sealed class SavePermissionTypeResult
    {
        public PermissionType Type { get; set; }
    }
}
