using Sorschia.Repositories;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using Sorschia.Utilities;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Repositories
{
    internal sealed class PermissionTypeRepository : RepositoryBase, IPermissionTypeRepository
    {
        public PermissionTypeRepository(IDependencyResolver dependencyResolver) : base(dependencyResolver)
        {
        }

        public Task<bool> DeleteAsync(DeletePermissionTypeModel model, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<IDeletePermissionType>();
            process.Model = model;
            return process.ExecuteAsync(cancellationToken);
        }

        public Task<PermissionType> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<IGetPermissionType>();
            process.Id = id;
            return process.ExecuteAsync(cancellationToken);
        }

        public Task<SavePermissionTypeResult> SaveAsync(SavePermissionTypeModel model, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<ISavePermissionType>();
            process.Model = model;
            return process.ExecuteAsync(cancellationToken);
        }

        public Task<SearchPermissionTypeResult> SearchAsync(SearchPermissionTypeModel model, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<ISearchPermissionType>();
            process.Model = model;
            return process.ExecuteAsync(cancellationToken);
        }
    }
}
