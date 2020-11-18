using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    public interface IDeletePermission : IAsyncProcess<bool>
    {
        DeletePermissionModel Model { get; set; }
    }
}
