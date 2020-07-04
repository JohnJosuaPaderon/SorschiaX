using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    interface IDeleteUser : IAsyncProcess<bool>
    {
        DeleteUserModel Model { get; set; }
    }

    public sealed class DeleteUserModel
    {
        public int Id { get; set; }
        public bool IsCascaded { get; set; }
    }
}
