using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    public interface ISearchRole : IAsyncProcess<SearchRoleResult>
    {
        SearchRoleModel Model { get; set; }
    }
}
