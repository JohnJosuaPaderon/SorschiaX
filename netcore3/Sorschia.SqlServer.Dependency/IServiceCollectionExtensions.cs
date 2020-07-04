using Microsoft.Extensions.DependencyInjection;
using Sorschia.SystemCore;

namespace Sorschia
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSorschiaSqlServer(this IServiceCollection instance) => instance
            .AddSystemCore();
    }
}
