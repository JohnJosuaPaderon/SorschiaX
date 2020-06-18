using Sorschia.Caching;
using Sorschia.Utilities;
using System;

namespace Sorschia.Repositories
{
    public abstract class CachedRepositoryBase : RepositoryBase
    {
        protected readonly ICache _cache;
        protected readonly ICacheHelper _cacheHelper;

        public CachedRepositoryBase(IDependencyResolver dependencyResolver, ICache cache, ICacheHelper cacheHelper) : base(dependencyResolver)
        {
            _cache = cache;
            _cacheHelper = cacheHelper;
        }

        protected virtual bool TryGetFromCache<T>(string cacheKey, out T result)
        {
            _cacheHelper.ValidateKey(cacheKey);
            return _cache.Exists(cacheKey, out result);
        }

        protected virtual T TrySaveToCache<T>(string cacheKey, T value, TimeSpan? expiration = default, CacheExpirationMode expirationMode = CacheExpirationMode.Sliding, bool continueOnDefault = default)
        {
            _cacheHelper.ValidateKey(cacheKey);
            return _cache.Save(cacheKey, value, expiration, expirationMode, continueOnDefault);
        }

        protected virtual T TrySaveToCache<T>(string cacheKey, T value, long? expirationSeconds = default, CacheExpirationMode expirationMode = CacheExpirationMode.Sliding, bool continueOnDefault = default)
        {
            _cacheHelper.ValidateKey(cacheKey);
            return _cache.Save(cacheKey, value, expirationSeconds, expirationMode, continueOnDefault);
        }
    }
}
