using Microsoft.Extensions.DependencyInjection;
using Sorschia.SystemCore.Processes;

namespace Sorschia.SystemCore
{
    partial class IServiceCollectionExtensions
    {
        private static IServiceCollection AddProcesses(this IServiceCollection instance) => instance
            .AddTransient<IDeleteApplication, DeleteApplication>()
            .AddTransient<IDeleteModule, DeleteModule>()
            .AddTransient<IGetApplication, GetApplication>()
            .AddTransient<IGetModule, GetModule>()
            .AddTransient<ISaveApplication, SaveApplication>()
            .AddTransient<ISaveModule, SaveModule>()
            .AddTransient<ISearchApplication, SearchApplication>()
            .AddTransient<ISearchModule, SearchModule>();
    }
}
