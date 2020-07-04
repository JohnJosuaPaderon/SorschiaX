using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Repositories
{
    public interface IApplicationRepository
    {
        Task<bool> DeleteAsync(DeleteApplicationModel model, CancellationToken cancellationToken = default);
        Task<Application> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<SaveApplicationResult> SaveAsync(SaveApplicationModel model, CancellationToken cancellationToken = default);
        Task<SearchApplicationResult> SearchAsync(SearchApplicationModel model, CancellationToken cancellationToken = default);
    }
}
