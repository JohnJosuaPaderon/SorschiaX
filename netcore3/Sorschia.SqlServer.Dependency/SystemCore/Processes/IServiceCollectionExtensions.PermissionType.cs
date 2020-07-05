using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.SystemCore.Processes
{
    partial class IServiceCollectionExtensions
    {
        private static IServiceCollection AddPermmissionType(this IServiceCollection instance) => instance
            .AddTransient<IDeletePermissionType, DeletePermissionType>()
            .AddTransient<IGetPermissionType, GetPermissionType>()
            .AddTransient<ISavePermissionType, SavePermissionType>()
            .AddTransient<ISearchPermissionType, SearchPermissionType>();
    }
}
