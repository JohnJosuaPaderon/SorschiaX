using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    public interface IDeletePermissionGroup : IAsyncProcess<bool>
    {
        DeletePermissionGroupModel Model { get; set; }
    }

    public sealed class DeletePermissionGroupModel
    {
        public int Id { get; set; }
        public bool IsCascaded { get; set; }
    }
}
