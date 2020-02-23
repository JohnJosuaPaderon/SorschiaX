using Sorschia.SystemBase.Security.Entities;
using Sorschia.SystemBase.Security.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemBase.Security
{
    public interface ISystemBaseSecurityRepository
    {
        #region Application
        Task<bool> DeleteApplicationAsync(DeleteApplicationModel model, CancellationToken cancellationToken = default);
        Task<SystemApplication> GetApplicationAsync(int id, CancellationToken cancellationToken = default);
        Task<GetApplicationListResult> GetApplicationListAsync(GetApplicationListModel model, CancellationToken cancellationToken = default);
        Task<SaveApplicationResult> SaveApplicationAsync(SaveApplicationModel model, CancellationToken cancellationToken = default);
        #endregion

        #region ApplicationPlatform
        Task<bool> DeleteApplicationPlatformAsync(DeleteApplicationPlatformModel model, CancellationToken cancellationToken = default);
        Task<SystemApplicationPlatform> GetApplicationPlatformAsync(int id, CancellationToken cancellationToken = default);
        Task<GetApplicationPlatformListResult> GetApplicationPlatformListAsync(GetApplicationPlatformListModel model, CancellationToken cancellationToken = default);
        Task<SaveApplicationPlatformResult> SaveApplicationPlatformAsync(SaveApplicationPlatformModel model, CancellationToken cancellationToken = default); 
        #endregion

        #region Module
        Task<bool> DeleteModuleAsync(DeleteModuleModel model, CancellationToken cancellationToken = default);
        Task<SystemModule> GetModuleAsync(int id, CancellationToken cancellationToken = default);
        Task<GetModuleListResult> GetModuleListAsync(GetModuleListModel model, CancellationToken cancellationToken = default);
        Task<SaveModuleResult> SaveModuleAsync(SaveModuleModel model, CancellationToken cancellationToken = default);
        #endregion

        #region Permission
        Task<bool> DeletePermissionAsync(DeletePermissionModel model, CancellationToken cancellationToken = default);
        Task<SystemPermission> GetPermissionAsync(int id, CancellationToken cancellationToken = default);
        Task<GetPermissionListResult> GetPermissionListAsync(GetPermissionListModel model, CancellationToken cancellationToken = default);
        Task<SavePermissionResult> SavePermissionAsync(SavePermissionModel model, CancellationToken cancellationToken = default);
        #endregion

        #region User
        Task<bool> DeleteUserAsync(DeleteUserModel model, CancellationToken cancellationToken = default);
        Task<SystemUser> GetUserAsync(int id, CancellationToken cancellationToken = default);
        Task<GetUserListResult> GetUserListAsync(GetUserListModel model, CancellationToken cancellationToken = default);
        Task<SaveUserResult> SaveUserAsync(SaveUserModel model, CancellationToken cancellationToken = default); 
        #endregion
    }
}
