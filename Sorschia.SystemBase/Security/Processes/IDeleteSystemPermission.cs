using Sorschia.Process;
using Sorschia.SystemBase.Security.Entities;

namespace Sorschia.SystemBase.Security.Processes
{
    public interface IDeleteSystemPermission : IAsyncProcess<bool>
    {
        DeleteSystemPermissionModel Model { get; set; }
    }

    public sealed class DeleteSystemPermissionModel
    {
        public SystemPermission Permission { get; set; }
    }
}
