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
    internal sealed class PlatformCachedRepository : CachedRepositoryBase, IPlatformRepository
    {
        private readonly SystemCoreConfiguration.CacheExpirationSection.PlatformSection _cacheExpiration;

        public PlatformCachedRepository(IDependencyResolver dependencyResolver, ICache cache, ICacheHelper cacheHelper, SystemCoreConfiguration configuration) : base(dependencyResolver, cache, cacheHelper)
        {
            _cacheExpiration = configuration.CacheExpiration.Platform;
        }

        public async Task<bool> DeleteAsync(DeletePlatformModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = _cacheHelper.CreateKey<DeletePlatformModel, bool>(model);

            if (TryGetFromCache(cacheKey, out bool result)) return result;

            using var process = GetProcess<IDeletePlatform>();
            process.Model = model;
            return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _cacheExpiration.Delete);
        }

        public async Task<Platform> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var cacheKey = _cacheHelper.CreateKey<int, Platform>(id);

            if (TryGetFromCache(cacheKey, out Platform platform)) return platform;

            using var process = GetProcess<IGetPlatform>();
            process.Id = id;
            return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _cacheExpiration.Get);
        }

        public async Task<SavePlatformResult> SaveAsync(SavePlatformModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = _cacheHelper.CreateKey<SavePlatformModel, SavePlatformResult>(model);

            if (TryGetFromCache(cacheKey, out SavePlatformResult result)) return result;

            using var process = GetProcess<ISavePlatform>();
            process.Model = model;
            return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _cacheExpiration.Save);
        }

        public async Task<SearchPlatformResult> SearchAsync(SearchPlatformModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = _cacheHelper.CreateKey<SearchPlatformModel, SearchPlatformResult>(model);

            if (TryGetFromCache(cacheKey, out SearchPlatformResult result)) return result;

            using var process = GetProcess<ISearchPlatform>();
            process.Model = model;
            return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _cacheExpiration.Search);
        }
    }
}
