using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    public interface ISearchRolePermission : IAsyncProcess<SearchRolePermissionResult>
    {
        SearchRolePermissionModel Model { get; set; }
    }
}
