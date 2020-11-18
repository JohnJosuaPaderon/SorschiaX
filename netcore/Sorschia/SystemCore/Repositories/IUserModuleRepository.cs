using Sorschia.SystemCore.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Repositories
{
    public interface IUserModuleRepository
    {
        Task<SearchUserModuleResult> SearchAsync(SearchUserModuleModel model, CancellationToken cancellationToken = default);
    }
}
