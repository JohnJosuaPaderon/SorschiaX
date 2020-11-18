using Sorschia.SystemCore.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Repositories
{
    public interface IUserRoleRepository
    {
        Task<SearchUserRoleResult> SearchAsync(SearchUserRoleModel model, CancellationToken cancellationToken = default);
    }
}
