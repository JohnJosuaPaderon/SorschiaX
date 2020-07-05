using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Repositories
{
    public interface IPermissionGroupRepository
    {
        Task<bool> DeleteAsync(DeletePermissionGroupModel model, CancellationToken cancellationToken = default);
        Task<PermissionGroup> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<SavePermissionGroupResult> SaveAsync(SavePermissionGroupModel model, CancellationToken cancellationToken = default);
        Task<SearchPermissionGroupResult> SearchAsync(SearchPermissionGroupModel model, CancellationToken cancellationToken = default);
    }
}
