using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.Data
{
    internal static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddData(this IServiceCollection instance) => instance
            .AddSingleton<IConnectionStringProvider, ConnectionStringProvider>();
    }
}
