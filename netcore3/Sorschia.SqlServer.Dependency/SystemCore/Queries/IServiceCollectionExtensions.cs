using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.SystemCore.Queries
{
    internal static partial class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSystemCoreQueries(this IServiceCollection instance) => instance
            .AddSingleton<SaveAccessTokenQuery>()
            .AddSingleton<SaveRefreshTokenQuery>()
            .AddApiPermission()
            .AddApplication()
            .AddModule()
            .AddPermission()
            .AddPermissionGroup()
            .AddPermissionType()
            .AddPlatform()
            .AddSession()
            .AddUser()
            .AddUserApplication()
            .AddUserModule()
            .AddUserPermission();
    }
}
