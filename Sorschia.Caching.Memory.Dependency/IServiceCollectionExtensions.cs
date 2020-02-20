using Microsoft.Extensions.DependencyInjection;
using Sorschia.Caching;
using System;

namespace Sorschia
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSorschiaMemoryCache(this IServiceCollection instance, Action<CacheSettings> configureSettings = default)
        {
            var cacheSettings = new CacheSettings
            {
                UseCaching = true,
                ExpirationMode = CacheExpirationMode.Absolute
            };

            configureSettings?.Invoke(cacheSettings);

            instance.AddMemoryCache();

            return instance
                .AddSingleton<ICache, Cache>()
                .AddSingleton(cacheSettings);
        }
    }
}
