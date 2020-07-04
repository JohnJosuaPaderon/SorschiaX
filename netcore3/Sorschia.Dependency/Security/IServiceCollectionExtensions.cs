using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.Security
{
    internal static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSecurity(this IServiceCollection instance, SecurityDependencySettings dependencySettings)
        {
            if (dependencySettings is null)
                throw SorschiaException.DependencySettingsIsNull<SecurityDependencySettings>();

            if (dependencySettings.UseAesCrypto)
                instance.AddSingleton<AesCrypto>();

            if (dependencySettings.UseCryptoHash)
                instance.AddSingleton<CryptoHash>();

            return instance;
        }
    }
}
