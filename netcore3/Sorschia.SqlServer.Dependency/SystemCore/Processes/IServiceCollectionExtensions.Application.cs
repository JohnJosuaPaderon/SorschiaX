using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.SystemCore.Processes
{
    partial class IServiceCollectionExtensions
    {
        private static IServiceCollection AddApplication(this IServiceCollection instance) => instance
            .AddTransient<IDeleteApplication, DeleteApplication>()
            .AddTransient<IGetApplication, GetApplication>()
            .AddTransient<ISaveApplication, SaveApplication>()
            .AddTransient<ISearchApplication, SearchApplication>();
    }
}
