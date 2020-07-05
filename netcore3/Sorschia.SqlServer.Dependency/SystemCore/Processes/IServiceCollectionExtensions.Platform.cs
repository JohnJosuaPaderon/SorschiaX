using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.SystemCore.Processes
{
    partial class IServiceCollectionExtensions
    {
        private static IServiceCollection AddPlatform(this IServiceCollection instance) => instance
            .AddTransient<IDeletePlatform, DeletePlatform>()
            .AddTransient<IGetPlatform, GetPlatform>()
            .AddTransient<ISavePlatform, SavePlatform>()
            .AddTransient<ISearchPlatform, SearchPlatform>();
    }
}
