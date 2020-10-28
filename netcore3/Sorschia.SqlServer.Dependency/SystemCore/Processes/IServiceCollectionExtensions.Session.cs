using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.SystemCore.Processes
{
    partial class IServiceCollectionExtensions
    {
        private static IServiceCollection AddSession(this IServiceCollection instance) => instance
            .AddTransient<IGetSession, GetSession>();
    }
}
