using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    public interface IDeletePermission : IAsyncProcess<bool>
    {
        DeletePermissionModel Model { get; set; }
    }

    public sealed class DeletePermissionModel
    {
        public int Id { get; set; }
        public bool IsCascaded { get; set; }
    }
}
