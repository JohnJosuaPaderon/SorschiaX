using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.SystemCore.Queries
{
    partial class IServiceCollectionExtensions
    {
        private static IServiceCollection AddUserPermission(this IServiceCollection instance) => instance
            .AddSingleton<DeleteUserPermissionQuery>()
            .AddSingleton<SaveUserPermissionQuery>();
    }
}
