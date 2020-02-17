using Microsoft.Extensions.Caching.Memory;
using System;

namespace Sorschia.Caching
{
    internal sealed class Cache : ICache
    {
        public Cache(IMemoryCache cache)
        {
            _memoryCache = cache;
        }

        private readonly IMemoryCache _memoryCache;

        private TimeSpan? GetExpirationFromSeconds(long? expirationSeconds)
        {
            if (expirationSeconds != null)
            {
                return TimeSpan.FromSeconds(expirationSeconds ?? 0);
            }

            return default;
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
            ValidateKey(key);

            lock (_memoryCache)
            {
                return _memoryCache.TryGetValue(key, out _);
            }
        }

        public bool Exists(string key, out object value)
        {
            ValidateKey(key);

            lock (_memoryCache)
            {
                return _memoryCache.TryGetValue(key, out value);
            }
        }

        public bool Exists<T>(string key, out T value)
        {
            ValidateKey(key);

            lock (_memoryCache)
            {
                return _memoryCache.TryGetValue(key, out value);
            }
        }

        public void Remove(string key)
        {
            ValidateKey(key);

            lock (_memoryCache)
            {
                _memoryCache.Remove(key);
            }
        }

        public object Save(string key, object value, TimeSpan? expiration = default, bool continueOnNull = default)
        {
            ValidateKey(key);

            lock (_memoryCache)
            {
                if (continueOnNull || value != null)
                {
                    if (expiration != null)
                    {
                        _memoryCache.Set(key, value, expiration.Value);
                    }
                    else
                    {
                        _memoryCache.Set(key, value);
                    }
                }
            }

            return value;
        }

        public object Save(string key, object value, long? expirationSeconds = default, bool continueOnNull = default)
        {
            return Save(key, value, GetExpirationFromSeconds(expirationSeconds), continueOnNull);
        }

        public T Save<T>(string key, T value, TimeSpan? expiration = null, bool continueOnDefault = false)
        {
            ValidateKey(key);

            lock (_memoryCache)
            {
                if (continueOnDefault || !Equals(value, default(T)))
                {
                    if (expiration != null)
                    {
                        _memoryCache.Set(key, value, expiration.Value);
                    }
                    else
                    {
                        _memoryCache.Set(key, value);
                    }
                }
            }

            return value;
        }

        public T Save<T>(string key, T value, long? expirationSeconds = default, bool continueOnDefault = default)
        {
            return Save(key, value, GetExpirationFromSeconds(expirationSeconds), continueOnDefault);
        }
    }
}
