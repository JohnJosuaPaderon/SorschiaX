using Sorschia.Caching;
using Sorschia.Repositories;
using Sorschia.SystemCore.Configuration;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using Sorschia.Utilities;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Repositories
{
    internal sealed class ModuleCachedRepository : CachedRepositoryBase, IModuleRepository
    {
        private readonly SystemCoreConfiguration.CacheExpirationSection.ModuleSection _cacheExpiration;

        public ModuleCachedRepository(IDependencyResolver dependencyResolver, ICache cache, ICacheHelper cacheHelper, SystemCoreConfiguration configuration) : base(dependencyResolver, cache, cacheHelper)
        {
            _cacheExpiration = configuration.CacheExpiration.Module;
        }

        public async Task<bool> DeleteAsync(DeleteModuleModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = _cacheHelper.CreateKey<DeleteModuleModel, bool>(model);

            if (TryGetFromCache(cacheKey, out bool result)) return result;

            using var process = GetProcess<IDeleteModule>();
            process.Model = model;
            return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _cacheExpiration.Delete);
        }

        public async Task<Module> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var cacheKey = _cacheHelper.CreateKey<int, Module>(id);

            if (TryGetFromCache(cacheKey, out Module module)) return module;

            using var process = GetProcess<IGetModule>();
            process.Id = id;
            return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _cacheExpiration.Get);
        }

        public async Task<SaveModuleResult> SaveAsync(SaveModuleModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = _cacheHelper.CreateKey<SaveModuleModel, SaveModuleResult>(model);

            if (TryGetFromCache(cacheKey, out SaveModuleResult result)) return result;

            using var process = GetProcess<ISaveModule>();
            process.Model = model;
            return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _cacheExpiration.Save);
        }

        public async Task<SearchModuleResult> SearchAsync(SearchModuleModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = _cacheHelper.CreateKey<SearchModuleModel, SearchModuleResult>(model);

            if (TryGetFromCache(cacheKey, out SearchModuleResult result)) return result;

            using var process = GetProcess<ISearchModule>();
            process.Model = model;
            return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _cacheExpiration.Search);
        }
    }
}
