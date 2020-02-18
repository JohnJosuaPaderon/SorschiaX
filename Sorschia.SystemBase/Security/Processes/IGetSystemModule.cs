using Sorschia.Process;
using Sorschia.SystemBase.Security.Entities;

namespace Sorschia.SystemBase.Security.Processes
{
    public interface IGetSystemModule : IAsyncProcess<SystemModule>
    {
        int Id { get; set; }
    }
}
