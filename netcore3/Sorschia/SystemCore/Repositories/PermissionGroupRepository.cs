using Sorschia.Repositories;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using Sorschia.Utilities;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Repositories
{
    internal sealed class PermissionGroupRepository : RepositoryBase, IPermissionGroupRepository
    {
        public PermissionGroupRepository(IDependencyResolver dependencyResolver) : base(dependencyResolver)
        {
        }

        public Task<bool> DeleteAsync(DeletePermissionGroupModel model, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<IDeletePermissionGroup>();
            process.Model = model;
            return process.ExecuteAsync(cancellationToken);
        }

        public Task<PermissionGroup> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<IGetPermissionGroup>();
            process.Id = id;
            return process.ExecuteAsync(cancellationToken);
        }

        public Task<SavePermissionGroupResult> SaveAsync(SavePermissionGroupModel model, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<ISavePermissionGroup>();
            process.Model = model;
            return process.ExecuteAsync(cancellationToken);
        }

        public Task<SearchPermissionGroupResult> SearchAsync(SearchPermissionGroupModel model, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<ISearchPermissionGroup>();
            process.Model = model;
            return process.ExecuteAsync(cancellationToken);
        }
    }
}
