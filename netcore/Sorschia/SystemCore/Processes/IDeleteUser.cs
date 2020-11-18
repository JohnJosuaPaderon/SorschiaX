using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    public interface IDeleteUser : IAsyncProcess<bool>
    {
        DeleteUserModel Model { get; set; }
    }
}
