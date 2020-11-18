using Sorschia.SystemCore.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Repositories
{
    public interface IUserPermissionRepository
    {
        Task<SearchUserPermissionResult> SearchAsync(SearchUserPermissionModel model, CancellationToken cancellationToken = default);
    }
}
