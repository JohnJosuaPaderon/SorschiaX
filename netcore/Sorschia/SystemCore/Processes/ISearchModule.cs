using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    public interface ISearchModule : IAsyncProcess<SearchModuleResult>
    {
        SearchModuleModel Model { get; set; }
    }
}
