using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.SystemCore.Processes
{
    partial class IServiceCollectionExtensions
    {
        private static IServiceCollection AddModule(this IServiceCollection instance) => instance
            .AddTransient<IDeleteModule, DeleteModule>()
            .AddTransient<IGetModule, GetModule>()
            .AddTransient<ISaveModule, SaveModule>()
            .AddTransient<ISearchModule, SearchModule>();
    }
}
