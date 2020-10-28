using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.SystemCore.Queries
{
    partial class IServiceCollectionExtensions
    {
        private static IServiceCollection AddSession(this IServiceCollection instance) => instance
            .AddSingleton<GetSessionQuery>()
            .AddSingleton<StartSessionQuery>();
    }
}
