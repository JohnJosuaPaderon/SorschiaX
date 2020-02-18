using Sorschia.Process;
using Sorschia.SystemBase.Security.Entities;

namespace Sorschia.SystemBase.Security.Processes
{
    public interface IGetSystemUser : IAsyncProcess<SystemUser>
    {
        int Id { get; set; }
    }
}
