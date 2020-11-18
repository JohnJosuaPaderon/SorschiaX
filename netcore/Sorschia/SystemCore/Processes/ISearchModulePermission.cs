using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    public interface ISearchModulePermission : IAsyncProcess<SearchModulePermissionResult>
    {
        SearchModulePermissionModel Model { get; set; }
    }
}
