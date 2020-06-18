using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.Caching
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSorschiaCaching(this IServiceCollection instance)
        {
            instance
                .AddMemoryCache()
                .AddSingleton<ICache, Cache>()
                .AddSingleton<ICacheHelper, CacheHelper>();

            return instance;
        }
    }
}
