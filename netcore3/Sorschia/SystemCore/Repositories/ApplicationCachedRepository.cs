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
    internal sealed class ApplicationCachedRepository : CachedRepositoryBase, IApplicationRepository
    {
        private readonly SystemCoreConfiguration.CacheExpirationSection.ApplicationSection _cacheExpiration;

        public ApplicationCachedRepository(IDependencyResolver dependencyResolver, ICache cache, ICacheHelper cacheHelper, SystemCoreConfiguration configuration) : base(dependencyResolver, cache, cacheHelper)
        {
            _cacheExpiration = configuration.CacheExpiration.Application;
        }

        public async Task<bool> DeleteAsync(DeleteApplicationModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = _cacheHelper.CreateKey<DeleteApplicationModel, bool>(model);

            if (TryGetFromCache(cacheKey, out bool result)) return result;

            using var process = GetProcess<IDeleteApplication>();
            process.Model = model;
            return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _cacheExpiration.Delete);
        }

        public async Task<Application> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var cacheKey = _cacheHelper.CreateKey<int, Application>(id);

            if (TryGetFromCache(cacheKey, out Application application)) return application;

            using var process = GetProcess<IGetApplication>();
            process.Id = id;
            return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _cacheExpiration.Get);
        }

        public async Task<SaveApplicationResult> SaveAsync(SaveApplicationModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = _cacheHelper.CreateKey<SaveApplicationModel, SaveApplicationResult>(model);

            if (TryGetFromCache(cacheKey, out SaveApplicationResult result)) return result;

            using var process = GetProcess<ISaveApplication>();
            process.Model = model;
            return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _cacheExpiration.Save);
        }

        public async Task<SearchApplicationResult> SearchAsync(SearchApplicationModel model, CancellationToken cancellationToken = default)
        {
            var cacheKey = _cacheHelper.CreateKey<SearchApplicationModel, SearchApplicationResult>(model);

            if (TryGetFromCache(cacheKey, out SearchApplicationResult result)) return result;

            using var process = GetProcess<ISearchApplication>();
            process.Model = model;
            return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _cacheExpiration.Search);
        }
    }
}
