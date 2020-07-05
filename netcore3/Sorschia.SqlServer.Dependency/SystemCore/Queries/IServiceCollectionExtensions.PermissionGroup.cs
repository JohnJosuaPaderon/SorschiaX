using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.SystemCore.Queries
{
    partial class IServiceCollectionExtensions
    {
        private static IServiceCollection AddPermissionGroup(this IServiceCollection instance) => instance
            .AddSingleton<DeletePermissionGroupQuery>()
            .AddSingleton<GetPermissionGroupQuery>()
            .AddSingleton<SavePermissionGroupQuery>()
            .AddSingleton<SearchPermissionGroupQuery>();
    }
}
