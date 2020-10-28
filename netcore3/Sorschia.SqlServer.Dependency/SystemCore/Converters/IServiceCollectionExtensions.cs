using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.SystemCore.Converters
{
    internal static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSystemCoreConverters(this IServiceCollection instance) => instance
            .AddSingleton<ApplicationConverter>()
            .AddSingleton<ModuleConverter>()
            .AddSingleton<PermissionConverter>()
            .AddSingleton<PermissionGroupConverter>()
            .AddSingleton<PlatformConverter>()
            .AddSingleton<SessionConverter>()
            .AddSingleton<UserConverter>();
    }
}
