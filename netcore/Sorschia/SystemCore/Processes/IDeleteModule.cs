using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    public interface IDeleteModule : IAsyncProcess<bool>
    {
        DeleteModuleModel Model { get; set; }
    }
}
