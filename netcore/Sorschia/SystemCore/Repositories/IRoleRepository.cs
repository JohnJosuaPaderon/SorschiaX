using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Repositories
{
    public interface IRoleRepository
    {
        Task<bool> DeleteAsync(DeleteRoleModel model, CancellationToken cancellationToken = default);
        Task<Role> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<SaveRoleResult> SaveAsync(SaveRoleModel model, CancellationToken cancellationToken = default);
        Task<SearchRoleResult> SearchAsync(SearchRoleModel model, CancellationToken cancellationToken = default);
    }
}
