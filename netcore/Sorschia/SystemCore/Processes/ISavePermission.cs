using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    public interface ISavePermission : IAsyncProcess<SavePermissionResult>
    {
        SavePermissionModel Model { get; set; }
    }
}
