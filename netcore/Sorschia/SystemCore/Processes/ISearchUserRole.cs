using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    public interface ISearchUserRole : IAsyncProcess<SearchUserRoleResult>
    {
        SearchUserRoleModel Model { get; set; }
    }
}
