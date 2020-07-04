using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Repositories
{
    public interface IModuleRepository
    {
        Task<bool> DeleteAsync(DeleteModuleModel model, CancellationToken cancellationToken = default);
        Task<Module> GetAsync(int id, CancellationToken cancellationToken = default);
        Task<SaveModuleResult> SaveAsync(SaveModuleModel model, CancellationToken cancellationToken = default);
        Task<SearchModuleResult> SearchAsync(SearchModuleModel model, CancellationToken cancellationToken = default);
    }
}
