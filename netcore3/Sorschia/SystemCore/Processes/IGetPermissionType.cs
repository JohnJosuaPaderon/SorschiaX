using Sorschia.Processes;
using Sorschia.SystemCore.Entities;

namespace Sorschia.SystemCore.Processes
{
    public interface IGetPermissionType : IAsyncProcess<PermissionType>
    {
        int Id { get; set; }
    }
}
