using Sorschia.Process;
using Sorschia.SystemBase.Security.Entities;

namespace Sorschia.SystemBase.Security.Processes
{
    public interface IDeleteSystemModule : IAsyncProcess<bool>
    {
        DeleteSystemModuleModel Model { get; set; }
    }

    public sealed class DeleteSystemModuleModel
    {
        public SystemModule Module { get; set; }
    }
}
