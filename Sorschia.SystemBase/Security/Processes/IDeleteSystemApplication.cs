using Sorschia.Process;
using Sorschia.SystemBase.Security.Entities;

namespace Sorschia.SystemBase.Security.Processes
{
    public interface IDeleteSystemApplication : IAsyncProcess<bool>
    {
        DeleteSystemApplicationModel Model { get; set; }
    }

    public sealed class DeleteSystemApplicationModel
    {
        public SystemApplication Application { get; set; }
        public bool IsCascadeDeleteModule { get; set; }
    }
}
