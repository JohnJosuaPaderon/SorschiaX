using Sorschia.Processes;
using Sorschia.SystemCore.Entities;

namespace Sorschia.SystemCore.Processes
{
    public interface IGetPermission : IAsyncProcess<Permission>
    {
        int Id { get; set; }
    }
}
