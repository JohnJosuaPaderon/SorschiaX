using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.SystemCore
{
    internal static partial class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSystemCore(this IServiceCollection instance) => instance
            .AddConverters()
            .AddProcesses()
            .AddQueries();
    }
}
