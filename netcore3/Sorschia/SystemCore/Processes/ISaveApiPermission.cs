using Sorschia.Processes;
using Sorschia.SystemCore.Entities;

namespace Sorschia.SystemCore.Processes
{
    public interface ISaveApiPermission : IAsyncProcess<SaveApiPermissionResult>
    {
        SaveApiPermissionModel Model { get; set; }
    }

    public sealed class SaveApiPermissionModel : SavePermissionModelBase
    {
        public ApiPermission Permission { get; set; }
    }

    public sealed class SaveApiPermissionResult : SavePermissionResultBase
    {
        public ApiPermission Permission { get; set; }
    }
}
