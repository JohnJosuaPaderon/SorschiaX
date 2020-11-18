using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    public interface ISearchUserApplication : IAsyncProcess<SearchUserApplicationResult>
    {
        SearchUserApplicationModel Model { get; set; }
    }
}
