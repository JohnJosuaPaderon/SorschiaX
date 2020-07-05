using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.SystemCore.Queries
{
    partial class IServiceCollectionExtensions
    {
        private static IServiceCollection AddApiPermission(this IServiceCollection instance) => instance
            .AddSingleton<GetApiPermissionQuery>()
            .AddSingleton<SaveApiPermissionQuery>();
    }
}
