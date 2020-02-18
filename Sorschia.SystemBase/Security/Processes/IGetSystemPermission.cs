using Sorschia.Process;
using Sorschia.SystemBase.Security.Entities;

namespace Sorschia.SystemBase.Security.Processes
{
    public interface IGetSystemPermission : IAsyncProcess<SystemPermission>
    {
        int Id { get; set; }
    }
}
