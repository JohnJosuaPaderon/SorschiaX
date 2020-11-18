using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    public interface ISaveApplication : IAsyncProcess<SaveApplicationResult>
    {
        SaveApplicationModel Model { get; set; }
    }
}
