using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.SystemCore.Processes
{
    partial class IServiceCollectionExtensions
    {
        private static IServiceCollection AddPermissionGroup(this IServiceCollection instance) => instance
            .AddTransient<IDeletePermissionGroup, DeletePermissionGroup>()
            .AddTransient<IGetPermissionGroup, GetPermissionGroup>()
            .AddTransient<ISavePermissionGroup, SavePermissionGroup>()
            .AddTransient<ISearchPermissionGroup, SearchPermissionGroup>();
    }
}
