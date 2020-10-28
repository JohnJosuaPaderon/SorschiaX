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
    internal sealed class SessionCachedRepository : CachedRepositoryBase, ISessionRepository
    {
        private readonly SystemCoreConfiguration.CacheExpirationSection.SessionSection _cacheExpiration;

        public SessionCachedRepository(IDependencyResolver dependencyResolver, ICache cache, ICacheHelper cacheHelper, SystemCoreConfiguration configuration) : base(dependencyResolver, cache, cacheHelper)
        {
            _cacheExpiration = configuration.CacheExpiration.Session;
        }

        public async Task<Session> GetAsync(long id, CancellationToken cancellationToken = default)
        {
            var cacheKey = _cacheHelper.CreateKey<long, Session>(id);

            if (TryGetFromCache(cacheKey, out Session session)) return session;

            using var process = GetProcess<IGetSession>();
            process.Id = id;
            return TrySaveToCache(cacheKey, await process.ExecuteAsync(cancellationToken), _cacheExpiration.Get);
        }
    }
}
