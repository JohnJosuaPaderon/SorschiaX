using Microsoft.Extensions.DependencyInjection;
using Sorschia.Security;

namespace Sorschia
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSorschia(this IServiceCollection instance)
        {
            return instance
                .AddSingleton<ICryptor, AesCryptor>()
                .AddSingleton<IDependencyProvider, DependencyProvider>();
        }
    }
}
