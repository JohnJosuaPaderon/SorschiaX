using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    public interface ISearchPermission : IAsyncProcess<SearchPermissionResult>
    {
        SearchPermissionModel Model { get; set; }
    }
}
