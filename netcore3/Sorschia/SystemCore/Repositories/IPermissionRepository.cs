using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Repositories
{
    public interface IPermissionRepository
    {
        Task<bool> DeleteAsync(DeletePermissionModel model, CancellationToken cancellationToken = default);
        Task<Permission> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<ApiPermission> GetApiPermissionAsync(int id, CancellationToken cancellationToken = default);
        Task<SavePermissionResult> SaveAsync(SavePermissionModel model, CancellationToken cancellationToken = default);
        Task<SaveApiPermissionResult> SaveApiPermissionAsync(SaveApiPermissionModel model, CancellationToken cancellationToken = default);
        Task<SearchPermissionResult> SearchAsync(SearchPermissionModel model, CancellationToken cancellationToken = default);
    }
}
