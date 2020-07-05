using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.SystemCore.Queries
{
    partial class IServiceCollectionExtensions
    {
        private static IServiceCollection AddModule(this IServiceCollection instance) => instance
            .AddSingleton<DeleteModuleQuery>()
            .AddSingleton<GetModuleQuery>()
            .AddSingleton<SaveModuleQuery>()
            .AddSingleton<SearchModuleQuery>();
    }
}
