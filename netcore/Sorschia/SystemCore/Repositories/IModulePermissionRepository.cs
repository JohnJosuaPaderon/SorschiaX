using Sorschia.SystemCore.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Repositories
{
    public interface IModulePermissionRepository
    {
        Task<SearchModulePermissionResult> SearchAsync(SearchModulePermissionModel model, CancellationToken cancellationToken = default);
    }
}
