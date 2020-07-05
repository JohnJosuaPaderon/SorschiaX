using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.SystemCore.Queries
{
    partial class IServiceCollectionExtensions
    {
        private static IServiceCollection AddApplication(this IServiceCollection instance) => instance
            .AddSingleton<DeleteApplicationQuery>()
            .AddSingleton<GetApplicationQuery>()
            .AddSingleton<SaveApplicationQuery>()
            .AddSingleton<SearchApplicationQuery>();
    }
}
