using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.SystemCore.Queries
{
    partial class IServiceCollectionExtensions
    {
        private static IServiceCollection AddPlatform(this IServiceCollection instance) => instance
            .AddSingleton<DeletePlatformQuery>()
            .AddSingleton<GetPlatformQuery>()
            .AddSingleton<SavePlatformQuery>()
            .AddSingleton<SearchPlatformQuery>();
    }
}
