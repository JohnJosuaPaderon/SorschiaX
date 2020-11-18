using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    public interface ISearchApplicationPermission : IAsyncProcess<SearchApplicationPermissionResult>
    {
        SearchApplicationPermissionModel Model { get; set; }
    }
}
