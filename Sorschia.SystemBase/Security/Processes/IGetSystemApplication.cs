using Sorschia.Process;
using Sorschia.SystemBase.Security.Entities;

namespace Sorschia.SystemBase.Security.Processes
{
    public interface IGetSystemApplication : IAsyncProcess<SystemApplication>
    {
        int Id { get; set; }
    }
}
