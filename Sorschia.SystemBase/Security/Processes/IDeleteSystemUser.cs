using Sorschia.Process;
using Sorschia.SystemBase.Security.Entities;

namespace Sorschia.SystemBase.Security.Processes
{
    public interface IDeleteSystemUser : IAsyncProcess<bool>
    {
        DeleteSystemUserModel Model { get; set; }
    }

    public sealed class DeleteSystemUserModel
    {
        public SystemUser User { get; set; }
    }
}
