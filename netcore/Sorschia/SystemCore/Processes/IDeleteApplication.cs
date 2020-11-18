using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    public interface IDeleteApplication : IAsyncProcess<bool>
    {
        DeleteApplicationModel Model { get; set; }
    }
}
