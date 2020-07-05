using Microsoft.Extensions.DependencyInjection;
using Sorschia.SystemCore.Processes;

namespace Sorschia.SystemCore
{
    partial class IServiceCollectionExtensions
    {
        private static IServiceCollection AddProcesses(this IServiceCollection instance) => instance
            .AddTransient<IDeleteApplication, DeleteApplication>()
            .AddTransient<IDeleteModule, DeleteModule>()
            .AddTransient<IDeletePermission, DeletePermission>()
            .AddTransient<IGetApiPermission, GetApiPermission>()
            .AddTransient<IGetApplication, GetApplication>()
            .AddTransient<IGetModule, GetModule>()
            .AddTransient<IGetPermission, GetPermission>()
            .AddTransient<ISaveApiPermission, SaveApiPermission>()
            .AddTransient<ISaveApplication, SaveApplication>()
            .AddTransient<ISaveModule, SaveModule>()
            .AddTransient<ISavePermission, SavePermission>()
            .AddTransient<ISearchApplication, SearchApplication>()
            .AddTransient<ISearchModule, SearchModule>()
            .AddTransient<ISearchPermission, SearchPermission>();
    }
}
