using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.SystemBase
{
    public static partial class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSorschiaSystemBaseSqlServer(this IServiceCollection instance)
        {
            return instance
                .InternalAddSecurity();
        }

        private static IServiceCollection InternalAddProcess<TContract, TImplementation>(this IServiceCollection instance)
            where TContract : class
            where TImplementation : class, TContract
        {
            return instance
                .AddTransient<TContract, TImplementation>();
        }

        private static IServiceCollection InternalAddProvider<TProvider>(this IServiceCollection instance)
            where TProvider : class
        {
            return instance.AddSingleton<TProvider>();
        }

        private static IServiceCollection InternalAddSecurity(this IServiceCollection instance)
        {
            return instance
                .InternalAddSecurityCommandProviders()
                .InternalAddSecurityFieldProviders()
                .InternalAddSecurityParameterProviders()
                .InternalAddSecurityProcesses();
        }
    }
}