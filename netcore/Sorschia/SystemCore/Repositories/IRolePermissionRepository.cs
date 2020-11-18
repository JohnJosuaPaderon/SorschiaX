using Sorschia.SystemCore.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Repositories
{
    public interface IRolePermissionRepository
    {
        Task<SearchRolePermissionResult> SearchAsync(SearchRolePermissionModel model, CancellationToken cancellationToken = default);
    }
}
