using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.SystemCore.Queries
{
    internal static partial class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSystemCoreQueries(this IServiceCollection instance) => instance
            .AddApiPermission()
            .AddApplication()
            .AddModule()
            .AddPermission()
            .AddPermissionGroup()
            .AddUserApplication()
            .AddUserModule()
            .AddUserPermission();
    }
}
