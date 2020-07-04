using Microsoft.Extensions.DependencyInjection;
using Sorschia.SystemCore.Converters;

namespace Sorschia.SystemCore
{
    partial class IServiceCollectionExtensions
    {
        private static IServiceCollection AddConverters(this IServiceCollection instance) => instance
            .AddSingleton<ApplicationConverter>()
            .AddSingleton<ModuleConverter>();
    }
}
