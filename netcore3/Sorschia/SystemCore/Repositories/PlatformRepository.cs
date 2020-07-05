using Sorschia.Repositories;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using Sorschia.Utilities;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Repositories
{
    internal sealed class PlatformRepository : RepositoryBase, IPlatformRepository
    {
        public PlatformRepository(IDependencyResolver dependencyResolver) : base(dependencyResolver)
        {
        }

        public Task<bool> DeleteAsync(DeletePlatformModel model, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<IDeletePlatform>();
            process.Model = model;
            return process.ExecuteAsync(cancellationToken);
        }

        public Task<Platform> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<IGetPlatform>();
            process.Id = id;
            return process.ExecuteAsync(cancellationToken);
        }

        public Task<SavePlatformResult> SaveAsync(SavePlatformModel model, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<ISavePlatform>();
            process.Model = model;
            return process.ExecuteAsync(cancellationToken);
        }

        public Task<SearchPlatformResult> SearchAsync(SearchPlatformModel model, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<ISearchPlatform>();
            process.Model = model;
            return process.ExecuteAsync(cancellationToken);
        }
    }
}
