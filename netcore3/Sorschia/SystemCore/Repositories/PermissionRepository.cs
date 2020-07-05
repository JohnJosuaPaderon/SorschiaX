using Sorschia.Repositories;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using Sorschia.Utilities;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Repositories
{
    internal sealed class PermissionRepository : RepositoryBase, IPermissionRepository
    {
        public PermissionRepository(IDependencyResolver dependencyResolver) : base(dependencyResolver)
        {
        }

        public Task<bool> DeleteAsync(DeletePermissionModel model, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<IDeletePermission>();
            process.Model = model;
            return process.ExecuteAsync(cancellationToken);
        }

        public Task<Permission> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<IGetPermission>();
            process.Id = id;
            return process.ExecuteAsync(cancellationToken);
        }

        public Task<ApiPermission> GetApiPermissionAsync(int id, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<IGetApiPermission>();
            process.Id = id;
            return process.ExecuteAsync(cancellationToken);
        }

        public Task<SavePermissionResult> SaveAsync(SavePermissionModel model, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<ISavePermission>();
            process.Model = model;
            return process.ExecuteAsync(cancellationToken);
        }

        public Task<SaveApiPermissionResult> SaveApiPermissionAsync(SaveApiPermissionModel model, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<ISaveApiPermission>();
            process.Model = model;
            return process.ExecuteAsync(cancellationToken);
        }

        public Task<SearchPermissionResult> SearchAsync(SearchPermissionModel model, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<ISearchPermission>();
            process.Model = model;
            return process.ExecuteAsync(cancellationToken);
        }
    }
}
