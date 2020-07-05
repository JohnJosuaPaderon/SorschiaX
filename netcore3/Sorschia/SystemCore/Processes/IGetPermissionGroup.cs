using Sorschia.Processes;
using Sorschia.SystemCore.Entities;

namespace Sorschia.SystemCore.Processes
{
    public interface IGetPermissionGroup : IAsyncProcess<PermissionGroup>
    {
        int Id { get; set; }
    }
}
