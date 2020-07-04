using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    public interface IDeletePermissionType : IAsyncProcess<bool>
    {
        DeletePermissionTypeModel Model { get; set; }
    }

    public sealed class DeletePermissionTypeModel
    {
        public int Id { get; set; }
        public bool IsCascaded { get; set; }
    }
}
