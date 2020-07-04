using Sorschia.Repositories;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using Sorschia.Utilities;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Repositories
{
    internal sealed class ModuleRepository : RepositoryBase, IModuleRepository
    {
        public ModuleRepository(IDependencyResolver dependencyResolver) : base(dependencyResolver)
        {
        }

        public Task<bool> DeleteAsync(DeleteModuleModel model, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<IDeleteModule>();
            process.Model = model;
            return process.ExecuteAsync(cancellationToken);
        }

        public Task<Module> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<IGetModule>();
            process.Id = id;
            return process.ExecuteAsync(cancellationToken);
        }

        public Task<SaveModuleResult> SaveAsync(SaveModuleModel model, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<ISaveModule>();
            process.Model = model;
            return process.ExecuteAsync(cancellationToken);
        }

        public Task<SearchModuleResult> SearchAsync(SearchModuleModel model, CancellationToken cancellationToken = default)
        {
            using var process = GetProcess<ISearchModule>();
            process.Model = model;
            return process.ExecuteAsync(cancellationToken);
        }
    }
}
