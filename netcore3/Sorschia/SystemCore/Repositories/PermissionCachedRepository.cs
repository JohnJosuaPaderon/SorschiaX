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
    internal sealed class PermissionCachedRepository : CachedRepositoryBase, IPermissionRepository
    {
        private readonly SystemCoreConfiguration.CacheExpirationSection.PermissionSection _cacheExpiration;

        public PermissionCachedRepository(IDependencyResolver dependencyResolver, ICache cache, ICacheHelper cacheHelper, SystemCoreConfiguration configuration) : base(dependencyResolver, cache, cacheHelper)
        {
            _cacheExpiration = configuration.CacheExpiration.Permission;
        }

        public async Task<bool> DeleteAsync(DeletePermissionModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = _cacheHelper.CreateKey<DeletePermissionModel, bool>(model);

            if (TryGetFromCache(cacheKey, out bool result)) return result;

            using var process = GetProcess<IDeletePermission>();
            process.Model = model;
            return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _cacheExpiration.Delete);
        }

        public async Task<Permission> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var cacheKey = _cacheHelper.CreateKey<int, Permission>(id);

            if (TryGetFromCache(cacheKey, out Permission permission)) return permission;

            using var process = GetProcess<IGetPermission>();
            process.Id = id;
            return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _cacheExpiration.Get);
        }

        public async Task<SavePermissionResult> SaveAsync(SavePermissionModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = _cacheHelper.CreateKey<SavePermissionModel, SavePermissionResult>(model);

            if (TryGetFromCache(cacheKey, out SavePermissionResult result)) return result;

            using var process = GetProcess<ISavePermission>();
            process.Model = model;
            return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _cacheExpiration.Save);
        }

        public async Task<SearchPermissionResult> SearchAsync(SearchPermissionModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = _cacheHelper.CreateKey<SearchPermissionModel, SearchPermissionResult>(model);

            if (TryGetFromCache(cacheKey, out SearchPermissionResult result)) return result;

            using var process = GetProcess<ISearchPermission>();
            process.Model = model;
            return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _cacheExpiration.Search);
        }
    }
}
