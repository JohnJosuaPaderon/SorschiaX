using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.SystemCore.Queries
{
    partial class IServiceCollectionExtensions
    {
        private static IServiceCollection AddPermission(this IServiceCollection instance) => instance
            .AddSingleton<DeletePermissionQuery>()
            .AddSingleton<GetPermissionQuery>()
            .AddSingleton<SavePermissionQuery>()
            .AddSingleton<SearchPermissionQuery>();
    }
}
