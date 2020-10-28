using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.SystemCore.Processes
{
    internal static partial class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSystemCoreProcesses(this IServiceCollection instance) => instance
            .AddApplication()
            .AddModule()
            .AddPermission()
            .AddPermissionGroup()
            .AddPlatform()
            .AddSession()
            .AddUser();
    }
}
