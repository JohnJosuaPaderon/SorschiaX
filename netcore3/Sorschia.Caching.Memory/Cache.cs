using Microsoft.Extensions.Caching.Memory;
using System;

namespace Sorschia.Caching
{
    internal sealed class Cache : ICache
    {
        private readonly IMemoryCache _memoryCache;

        public Cache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        private TimeSpan? GetExpirationFromSeconds(long? expirationSeconds) => expirationSeconds > 0 ? TimeSpan.FromSeconds(expirationSeconds ?? 0) : default;

        private MemoryCacheEntryOptions GetEntryOptions(TimeSpan? expiration, CacheExpirationMode expirationMode)
        {
            var result = new MemoryCacheEntryOptions();

            switch (expirationMode)
            {
                case CacheExpirationMode.Absolute:
                case CacheExpirationMode.Default:
                    result.AbsoluteExpirationRelativeToNow = expiration;
                    break;
                case CacheExpirationMode.Sliding:
                    result.SlidingExpiration = expiration;
                    break;
                default: throw new SorschiaCachingException($"Expiration Mode is not supported");
            }

            return result;
        }

        private void ValidateKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new SorschiaCachingException("Key is null or white-space");
        }

        public bool Exists(string key)
        {
            ValidateKey(key);
            lock (_memoryCache)
                return _memoryCache.TryGetValue(key, out _);
        }

        public bool Exists<T>(string key, out T value)
        {
            ValidateKey(key);
            lock (_memoryCache)
                return _memoryCache.TryGetValue(key, out value);
        }

        public void Remove(string key)
        {
            ValidateKey(key);
            lock (_memoryCache)
                _memoryCache.Remove(key);
        }

        public T Save<T>(string key, T value, TimeSpan? expiration = null, CacheExpirationMode expirationMode = CacheExpirationMode.Default, bool continueOnDefault = false)
        {
            ValidateKey(key);
            lock (_memoryCache)
            {
                if (continueOnDefault || !Equals(value, default(T)))
                {
                    if (expiration != default)
                        _memoryCache.Set(key, value, GetEntryOptions(expiration, expirationMode));
                    else
                        _memoryCache.Set(key, value);
                }
            }

            return value;
        }

        public T Save<T>(string key, T value, long? expirationSeconds = null, CacheExpirationMode expirationMode = CacheExpirationMode.Default, bool continueOnDefault = false) => Save(key, value, GetExpirationFromSeconds(expirationSeconds), expirationMode, continueOnDefault);
    }
}
