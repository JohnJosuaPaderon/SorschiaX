using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.SystemCore.Processes
{
    partial class IServiceCollectionExtensions
    {
        private static IServiceCollection AddPermission(this IServiceCollection instance) => instance
            .AddTransient<IDeletePermission, DeletePermission>()
            .AddTransient<IGetPermission, GetPermission>()
            .AddTransient<ISavePermission, SavePermission>()
            .AddTransient<ISearchPermission, SearchPermission>();
    }
}
