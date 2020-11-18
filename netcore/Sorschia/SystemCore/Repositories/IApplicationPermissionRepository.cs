using Sorschia.SystemCore.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Repositories
{
    public interface IApplicationPermissionRepository
    {
        Task<SearchApplicationPermissionResult> SearchAsync(SearchApplicationPermissionModel model, CancellationToken cancellationToken = default);
    }
}
