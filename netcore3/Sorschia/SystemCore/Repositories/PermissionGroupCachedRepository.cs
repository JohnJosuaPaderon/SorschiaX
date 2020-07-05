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
    internal sealed class PermissionGroupCachedRepository : CachedRepositoryBase, IPermissionGroupRepository
    {
        private readonly SystemCoreConfiguration.CacheExpirationSection.PermissionGroupSection _cacheExpiration;

        public PermissionGroupCachedRepository(IDependencyResolver dependencyResolver, ICache cache, ICacheHelper cacheHelper, SystemCoreConfiguration configuration) : base(dependencyResolver, cache, cacheHelper)
        {
            _cacheExpiration = configuration.CacheExpiration.PermissionGroup;
        }

        public async Task<bool> DeleteAsync(DeletePermissionGroupModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = _cacheHelper.CreateKey<DeletePermissionGroupModel, bool>(model);

            if (TryGetFromCache(cacheKey, out bool result)) return result;

            using var process = GetProcess<IDeletePermissionGroup>();
            process.Model = model;
            return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _cacheExpiration.Delete);
        }

        public async Task<PermissionGroup> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var cacheKey = _cacheHelper.CreateKey<int, PermissionGroup>(id);

            if (TryGetFromCache(cacheKey, out PermissionGroup group)) return group;

            using var process = GetProcess<IGetPermissionGroup>();
            process.Id = id;
            return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _cacheExpiration.Get);
        }

        public async Task<SavePermissionGroupResult> SaveAsync(SavePermissionGroupModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = _cacheHelper.CreateKey<SavePermissionGroupModel, SavePermissionGroupResult>(model);

            if (TryGetFromCache(cacheKey, out SavePermissionGroupResult result)) return result;

            using var process = GetProcess<ISavePermissionGroup>();
            process.Model = model;
            return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _cacheExpiration.Save);
        }

        public async Task<SearchPermissionGroupResult> SearchAsync(SearchPermissionGroupModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = _cacheHelper.CreateKey<SearchPermissionGroupModel, SearchPermissionGroupResult>(model);

            if (TryGetFromCache(cacheKey, out SearchPermissionGroupResult result)) return result;

            using var process = GetProcess<ISearchPermissionGroup>();
            process.Model = model;
            return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _cacheExpiration.Search);
        }
    }
}
