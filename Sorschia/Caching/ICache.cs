using System;

namespace Sorschia.Caching
{
    public interface ICache
    {
        object Save(string key, object value, TimeSpan? expiration = default, bool continueOnNull = default);
        object Save(string key, object value, long? expirationSeconds = default, bool continueOnNull = default);
        T Save<T>(string key, T value, TimeSpan? expiration = default, bool continueOnDefault = default);
        T Save<T>(string key, T value, long? expirationSeconds = default, bool continueOnDefault = default);
        void Remove(string key);
        bool Exists(string key);
        bool Exists(string key, out object value);
        bool Exists<T>(string key, out T value);
    }
}
