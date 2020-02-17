using Microsoft.Extensions.DependencyInjection;
using Sorschia.Caching;

namespace Sorschia
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSorschiaMemoryCache(this IServiceCollection instance)
        {
            instance.AddMemoryCache();

            return instance
                .AddSingleton<ICache, Cache>();
        }
    }
}
