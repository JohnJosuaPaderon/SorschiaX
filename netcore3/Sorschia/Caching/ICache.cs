using System;
using System.Collections.Generic;
using System.Text;

namespace Sorschia.Caching
{
    public interface ICache
    {
        T Save<T>(string key, T value, TimeSpan? expiration = default, CacheExpirationMode expirationMode = CacheExpirationMode.Sliding, bool continueOnDefault = default);
        T Save<T>(string key, T value, long? expirationSeconds = default, CacheExpirationMode expirationMode = CacheExpirationMode.Sliding, bool continueOnDefault = default);
        void Remove(string key);
        bool Exists(string key);
        bool Exists<T>(string key, out T value);
    }
}
