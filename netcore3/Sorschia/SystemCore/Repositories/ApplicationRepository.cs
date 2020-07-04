using Sorschia.Repositories;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using Sorschia.Utilities;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Repositories
{
    internal sealed class ApplicationRepository : RepositoryBase, IApplicationRepository
    {
        public ApplicationRepository(IDependencyResolver dependencyResolver) : base(dependencyResolver)
        {
        }

        public Task<bool> DeleteAsync(DeleteApplicationModel model, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<IDeleteApplication>();
            process.Model = model;
            return process.ExecuteAsync(cancellationToken);
        }

        public Task<Application> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<IGetApplication>();
            process.Id = id;
            return process.ExecuteAsync(cancellationToken);
        }

        public Task<SaveApplicationResult> SaveAsync(SaveApplicationModel model, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<ISaveApplication>();
            process.Model = model;
            return process.ExecuteAsync(cancellationToken);
        }

        public Task<SearchApplicationResult> SearchAsync(SearchApplicationModel model, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<ISearchApplication>();
            process.Model = model;
            return process.ExecuteAsync(cancellationToken);
        }
    }
}
