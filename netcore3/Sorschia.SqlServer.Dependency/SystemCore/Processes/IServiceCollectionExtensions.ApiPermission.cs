using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.SystemCore.Processes
{
    partial class IServiceCollectionExtensions
    {
        private static IServiceCollection AddApiPermission(this IServiceCollection instance) => instance
            .AddTransient<IGetApiPermission, GetApiPermission>()
            .AddTransient<ISaveApiPermission, SaveApiPermission>();
    }
}
