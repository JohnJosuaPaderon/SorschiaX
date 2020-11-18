using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    public interface ISaveUser : IAsyncProcess<SaveUserResult>
    {
        SaveUserModel Model { get; set; }
    }
}
