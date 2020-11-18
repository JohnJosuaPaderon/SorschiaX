using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    public interface ISearchApplication : IAsyncProcess<SearchApplicationResult>
    {
        SearchApplicationModel Model { get; set; }
    }
}
