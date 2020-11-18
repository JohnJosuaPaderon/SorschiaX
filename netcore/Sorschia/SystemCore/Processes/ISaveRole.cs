using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    public interface ISaveRole : IAsyncProcess<SaveRoleResult>
    {
        SaveRoleModel Model { get; set; }
    }
}
