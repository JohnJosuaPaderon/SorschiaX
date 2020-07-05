using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    public interface IDeleteUserPermission : IAsyncProcess<bool>
    {
        DeleteUserPermissionModel Model { get; set; }
    }

    public sealed class DeleteUserPermissionModel
    {
        public long Id { get; set; }
        public bool IsCascaded { get; set; }
    }
}
