using Microsoft.Extensions.DependencyInjection;
using Sorschia.SystemCore.Converters;
using Sorschia.SystemCore.Processes;
using Sorschia.SystemCore.Queries;

namespace Sorschia.SystemCore
{
    internal static partial class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSystemCore(this IServiceCollection instance) => instance
            .AddSystemCoreConverters()
            .AddSystemCoreProcesses()
            .AddSystemCoreQueries();
    }
}
