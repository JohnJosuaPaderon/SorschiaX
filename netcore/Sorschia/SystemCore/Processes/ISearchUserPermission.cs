using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    public interface ISearchUserPermission : IAsyncProcess<SearchUserPermissionResult>
    {
        SearchUserPermissionModel Model { get; set; }
    }
}
