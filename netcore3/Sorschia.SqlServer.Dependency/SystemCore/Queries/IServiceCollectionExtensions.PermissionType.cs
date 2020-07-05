using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.SystemCore.Queries
{
    partial class IServiceCollectionExtensions
    {
        private static IServiceCollection AddPermissionType(this IServiceCollection instance) => instance
            .AddSingleton<DeletePermissionTypeQuery>()
            .AddSingleton<GetPermissionTypeQuery>()
            .AddSingleton<SavePermissionTypeQuery>()
            .AddSingleton<SearchPermissionTypeQuery>();
    }
}
