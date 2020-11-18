using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    public interface ISearchUser : IAsyncProcess<SearchUserResult>
    {
        SearchUserModel Model { get; set; }
    }
}
