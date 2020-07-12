using Sorschia.Processes;

namespace Sorschia.SystemCore.Processes
{
    public interface IValidateUserPermission : IAsyncProcess<bool>
    {
        ValidateUserPermissionModel Model { get; set; }
    }

    public sealed class ValidateUserPermissionModel
    {
        public int UserId { get; set; }
        public int PermissionId { get; set; }
    }
}
