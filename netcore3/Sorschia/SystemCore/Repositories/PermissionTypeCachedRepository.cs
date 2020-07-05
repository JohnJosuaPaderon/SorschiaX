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
    internal sealed class PermissionTypeCachedRepository : CachedRepositoryBase, IPermissionTypeRepository
    {
        private readonly SystemCoreConfiguration.CacheExpirationSection.PermissionTypeSection _cacheExpiration;

        public PermissionTypeCachedRepository(IDependencyResolver dependencyResolver, ICache cache, ICacheHelper cacheHelper, SystemCoreConfiguration configuration) : base(dependencyResolver, cache, cacheHelper)
        {
            _cacheExpiration = configuration.CacheExpiration.PermissionType;
        }

        public async Task<bool> DeleteAsync(DeletePermissionTypeModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = _cacheHelper.CreateKey<DeletePermissionTypeModel, bool>(model);

            if (TryGetFromCache(cacheKey, out bool result)) return result;

            using var process = GetProcess<IDeletePermissionType>();
            process.Model = model;
            return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _cacheExpiration.Delete);
        }

        public async Task<PermissionType> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var cacheKey = _cacheHelper.CreateKey<int, PermissionType>(id);

            if (TryGetFromCache(cacheKey, out PermissionType type)) return type;

            using var process = GetProcess<IGetPermissionType>();
            process.Id = id;
            return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _cacheExpiration.Get);
        }

        public async Task<SavePermissionTypeResult> SaveAsync(SavePermissionTypeModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = _cacheHelper.CreateKey<SavePermissionTypeModel, SavePermissionTypeResult>(model);

            if (TryGetFromCache(cacheKey, out SavePermissionTypeResult result)) return result;

            using var process = GetProcess<ISavePermissionType>();
            process.Model = model;
            return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _cacheExpiration.Save);
        }

        public async Task<SearchPermissionTypeResult> SearchAsync(SearchPermissionTypeModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = _cacheHelper.CreateKey<SearchPermissionTypeModel, SearchPermissionTypeResult>(model);

            if (TryGetFromCache(cacheKey, out SearchPermissionTypeResult result)) return result;

            using var process = GetProcess<ISearchPermissionType>();
            process.Model = model;
            return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _cacheExpiration.Search);
        }
    }
}
