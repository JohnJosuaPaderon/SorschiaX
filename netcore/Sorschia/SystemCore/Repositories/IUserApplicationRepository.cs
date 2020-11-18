using Sorschia.SystemCore.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Repositories
{
    public interface IUserApplicationRepository
    {
        Task<SearchUserApplicationResult> SearchAsync(SearchUserApplicationModel model, CancellationToken cancellationToken = default);
    }
}
