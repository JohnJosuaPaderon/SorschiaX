using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Repositories
{
    public interface IPermissionTypeRepository
    {
        Task<bool> DeleteAsync(DeletePermissionTypeModel model, CancellationToken cancellationToken = default);
        Task<PermissionType> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<SavePermissionTypeResult> SaveAsync(SavePermissionTypeModel model, CancellationToken cancellationToken = default);
        Task<SearchPermissionTypeResult> SearchAsync(SearchPermissionTypeModel model, CancellationToken cancellationToken = default);
    }
}
