using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.Security
{
    internal static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSecurity(this IServiceCollection instance, SecurityDependencySettings dependencySettings)
        {
            if (dependencySettings == null)
                throw new SorschiaException("Dependency Settings is null");

            if (dependencySettings.UseAesCrypto)
                instance.AddSingleton<AesCrypto>();

            if (dependencySettings.UseCryptoHash)
                instance.AddSingleton<CryptoHash>();

            return instance;
        }
    }
}
