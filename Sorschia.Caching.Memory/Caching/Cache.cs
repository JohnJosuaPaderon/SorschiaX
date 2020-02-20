using Microsoft.Extensions.Caching.Memory;
using System;

namespace Sorschia.Caching
{
    internal sealed class Cache : ICache
    {
        public Cache(IMemoryCache cache, CacheSettings settings)
        {
            _memoryCache = cache;
            _settings = settings;
        }

        private readonly IMemoryCache _memoryCache;
        private readonly CacheSettings _settings;

        private TimeSpan? GetExpirationFromSeconds(long? expirationSeconds)
        {
            if (expirationSeconds != null)
            {
                return TimeSpan.FromSeconds(expirationSeconds.Value);
            }

            return default;
        }

        private MemoryCacheEntryOptions GetMemoryCacheEntryOptions(TimeSpan? expiration)
        {
            var result = new MemoryCacheEntryOptions();

            switch (_settings.ExpirationMode)
            {
                case CacheExpirationMode.Absolute:
                    result.AbsoluteExpirationRelativeToNow = expiration;
                    break;
                case CacheExpirationMode.Sliding:
                    result.SlidingExpiration = expiration;
                    break;
                default: throw new SorschiaCachingException("Selected expiration mode is currently unsupported");
            }

            return result;
        }

        private void ValidateKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new SorschiaCachingException($"Parameter '{key}' is null or white space.");
            }
        }

        public bool Exists(string key)
        {
            if (_settings.UseCaching)
            {
                ValidateKey(key);

                lock (_memoryCache)
                {
                    return _memoryCache.TryGetValue(key, out _);
                }
            }

            return false;
        }

        public bool Exists(string key, out object value)
        {
            if (_settings.UseCaching)
            {
                ValidateKey(key);

                lock (_memoryCache)
                {
                    return _memoryCache.TryGetValue(key, out value);
                }
            }

            value = default;
            return false;
        }

        public bool Exists<T>(string key, out T value)
        {
            if (_settings.UseCaching)
            {
                ValidateKey(key);

                lock (_memoryCache)
                {
                    return _memoryCache.TryGetValue(key, out value);
                }
            }

            value = default;
            return false;
        }

        public void Remove(string key)
        {
            if (_settings.UseCaching)
            {
                ValidateKey(key);

                lock (_memoryCache)
                {
                    _memoryCache.Remove(key);
                }
            }
        }

        public object Save(string key, object value, TimeSpan? expiration = default, bool continueOnNull = default)
        {
            if (_settings.UseCaching)
            {
                ValidateKey(key);

                lock (_memoryCache)
                {
                    if (continueOnNull || value != default)
                    {
                        if (expiration != default)
                        {
                            _memoryCache.Set(key, value, GetMemoryCacheEntryOptions(expiration));
                        }
                        else
                        {
                            _memoryCache.Set(key, value);
                        }
                    }
                }

                return value;
            }

            return default;
        }

        public object Save(string key, object value, long? expirationSeconds = default, bool continueOnNull = default)
        {
            return Save(key, value, GetExpirationFromSeconds(expirationSeconds), continueOnNull);
        }

        public T Save<T>(string key, T value, TimeSpan? expiration = null, bool continueOnDefault = false)
        {
            if (_settings.UseCaching)
            {
                ValidateKey(key);

                lock (_memoryCache)
                {
                    if (continueOnDefault || !Equals(value, default(T)))
                    {
                        if (expiration != default)
                        {
                            _memoryCache.Set(key, value, GetMemoryCacheEntryOptions(expiration));
                        }
                        else
                        {
                            _memoryCache.Set(key, value);
                        }
                    }
                }

                return value;
            }

            return default;
        }

        public T Save<T>(string key, T value, long? expirationSeconds = default, bool continueOnDefault = default)
        {
            return Save(key, value, GetExpirationFromSeconds(expirationSeconds), continueOnDefault);
        }
    }
}
