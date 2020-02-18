using Sorschia.SystemBase.Security.Entities;
using Sorschia.SystemBase.Security.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemBase.Security
{
    public interface ISystemBaseSecurityRepository
    {
        Task<bool> DeleteApplicationAsync(DeleteSystemApplicationModel model, CancellationToken cancellationToken = default);
        Task<bool> DeleteModuleAsync(DeleteSystemModuleModel model, CancellationToken cancellationToken = default);
        Task<bool> DeletePermissionAsync(DeleteSystemPermissionModel model, CancellationToken cancellationToken = default);
        Task<bool> DeleteUserAsync(DeleteSystemUserModel model, CancellationToken cancellationToken = default);
        Task<SystemApplication> GetApplicationAsync(int id, CancellationToken cancellationToken = default);
        Task<SystemModule> GetModuleAsync(int id, CancellationToken cancellationToken = default);
        Task<SystemPermission> GetPermissionAsync(int id, CancellationToken cancellationToken = default);
        Task<SystemUser> GetUserAsync(int id, CancellationToken cancellationToken = default);
        Task<SaveSystemApplicationResult> SaveApplicationAsync(SavesystemApplicationModel model, CancellationToken cancellationToken = default);
        Task<SaveSystemModuleResult> SaveModuleAsync(SaveSystemModuleModel model, CancellationToken cancellationToken = default);
        Task<SaveSystemPermissionResult> SavePermissionAsync(SaveSystemPermissionModel model, CancellationToken cancellationToken = default);
        Task<SaveSystemUserResult> SaveUserAsync(SaveSystemUserModel model, CancellationToken cancellationToken = default);
    }
}
