using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    public interface ISearchUserModule : IAsyncProcess<SearchUserModuleResult>
    {
        SearchUserModuleModel Model { get; set; }
    }
}
