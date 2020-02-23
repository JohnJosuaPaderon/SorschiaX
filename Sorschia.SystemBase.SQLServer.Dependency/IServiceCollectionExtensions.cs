using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.SystemBase
{
    public static partial class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSorschiaSystemBaseSqlServer(this IServiceCollection instance)
        {
            return instance
                .InternalAddCommandProviders()
                .InternalAddFieldProviders()
                .InternalAddParameterProviders()
                .InternalAddProcesses();
        }

        private static IServiceCollection InternalAddProcess<TContract, TImplementation>(this IServiceCollection instance)
            where TContract : class
            where TImplementation : class, TContract
        {
            return instance
                .AddTransient<TContract, TImplementation>();
        }

        private static IServiceCollection InternalAddCommandProvider<TCommandProvider>(this IServiceCollection instance)
            where TCommandProvider : class
        {
            return instance.AddSingleton<TCommandProvider>();
        }

        private static IServiceCollection InternalAddParameterProvider<TParameterProvider>(this IServiceCollection instance)
            where TParameterProvider : class
        {
            return instance.AddSingleton<TParameterProvider>();
        }

        private static IServiceCollection InternalAddFieldProvider<TFieldProvider>(this IServiceCollection instance)
            where TFieldProvider : class
        {
            return instance.AddSingleton<TFieldProvider>();
        }
    }
}