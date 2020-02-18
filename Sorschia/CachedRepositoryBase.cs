using Newtonsoft.Json;
using Sorschia.Caching;
using System.Text;

namespace Sorschia
{
    public abstract class CachedRepositoryBase : RepositoryBase
    {
        public CachedRepositoryBase(IDependencyProvider dependencyProvider, ICache cache) : base(dependencyProvider)
        {
            _cache = cache;
        }

        private readonly ICache _cache;

        private void ValidateCacheKey(string cacheKey)
        {
            if (string.IsNullOrWhiteSpace(cacheKey))
            {
                throw new SorschiaException("Cache key cannot be null or whitespace");
            }
        }

        protected bool TryGetFromCache<T>(string cacheKey, out T result)
        {
            ValidateCacheKey(cacheKey);
            return _cache.Exists(cacheKey, out result);
        }

        protected T TrySaveToCache<T>(string cacheKey, T value, long? expirationSeconds, bool continueOnDefault = default)
        {
            ValidateCacheKey(cacheKey);
            return _cache.Save(cacheKey, value, expirationSeconds, continueOnDefault);
        }

        protected string CreateCacheKey<TModel, TResult>(TModel model)
        {
            return CreateCacheKey<TModel, TResult>(null, model);
        }

        protected string CreateCacheKey<TModel, TResult>(string flag, TModel model)
        {
            var builder = new StringBuilder($"{typeof(TResult).FullName}@");

            if (Equals(model, default(TModel)))
            {
                builder.Append("~");
            }
            else
            {
                builder.Append(JsonConvert.SerializeObject(model, Formatting.None));
            }

            if (!string.IsNullOrWhiteSpace(flag))
            {
                builder.Append($"+{flag}");
            }

            return builder.ToString();
        }
    }
}
