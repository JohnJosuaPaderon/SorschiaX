using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    public interface ISaveModule : IAsyncProcess<SaveModuleResult>
    {
        SaveModuleModel Model { get; set; }
    }
}
