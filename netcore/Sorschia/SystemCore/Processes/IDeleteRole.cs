using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    public interface IDeleteRole : IAsyncProcess<bool>
    {
        DeleteRoleModel Model { get; set; }
    }
}
