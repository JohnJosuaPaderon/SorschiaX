using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Repositories
{
    public interface IPlatformRepository
    {
        Task<bool> DeleteAsync(DeletePlatformModel model, CancellationToken cancellationToken = default);
        Task<Platform> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<SavePlatformResult> SaveAsync(SavePlatformModel model, CancellationToken cancellationToken = default);
        Task<SearchPlatformResult> SearchAsync(SearchPlatformModel model, CancellationToken cancellationToken = default);
    }
}
