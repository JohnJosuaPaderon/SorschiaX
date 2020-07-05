using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.SystemCore.Converters
{
    internal static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSystemCoreConverters(this IServiceCollection instance) => instance
            .AddSingleton<ApiPermissionConverter>()
            .AddSingleton<ApplicationConverter>()
            .AddSingleton<ModuleConverter>()
            .AddSingleton<PermissionConverter>()
            .AddSingleton<PermissionGroupConverter>()
            .AddSingleton<PermissionTypeConverter>()
            .AddSingleton<PlatformConverter>();
    }
}
