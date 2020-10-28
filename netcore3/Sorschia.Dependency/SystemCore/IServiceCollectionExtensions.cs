using Microsoft.Extensions.DependencyInjection;
using Sorschia.SystemCore.Configuration;
using Sorschia.SystemCore.Repositories;

namespace Sorschia.SystemCore
{
    internal static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSystemCore(this IServiceCollection instance, SystemCoreDependencySettings dependencySettings)
        {
            if (dependencySettings is null)
                throw SorschiaException.DependencySettingsIsNull<SystemCoreDependencySettings>();

            instance
                .AddSingleton<IRefreshTokenGenerator, RefreshTokenGenerator>()
                .AddSingleton<IUserPasswordCryptoHash, UserPasswordCryptoHash>()
                .AddSingleton<IUserPasswordCryptoTransformer, UserPasswordCryptoTransformer>();

            switch (dependencySettings.RepositoryOption)
            {
                case RepositoryOption.Regular:
                    instance
                        .AddSingleton<IApplicationRepository, ApplicationRepository>()
                        .AddSingleton<IModuleRepository, ModuleRepository>()
                        .AddSingleton<IPermissionRepository, PermissionRepository>()
                        .AddSingleton<IPermissionGroupRepository, PermissionGroupRepository>()
                        .AddSingleton<IPlatformRepository, PlatformRepository>()
                        .AddSingleton<ISessionRepository, SessionRepository>()
                        .AddSingleton<IUserRepository, UserRepository>();
                    break;
                case RepositoryOption.Cached:
                    instance
                        .AddSingleton<IApplicationRepository, ApplicationCachedRepository>()
                        .AddSingleton<IModuleRepository, ModuleCachedRepository>()
                        .AddSingleton<IPermissionRepository, PermissionCachedRepository>()
                        .AddSingleton<IPermissionGroupRepository, PermissionGroupCachedRepository>()
                        .AddSingleton<IPlatformRepository, PlatformCachedRepository>()
                        .AddSingleton<ISessionRepository, SessionCachedRepository>()
                        .AddSingleton<IUserRepository, UserCachedRepository>();
                    break;
            }

            switch (dependencySettings.UserPasswordCryptoKeySource)
            {
                case UserPasswordCryptoKeySource.File:
                    if (string.IsNullOrWhiteSpace(dependencySettings.UserPasswordPrivateKeyFilePath))
                        throw new SorschiaException("User password private key file path is null or white-space");

                    if (string.IsNullOrWhiteSpace(dependencySettings.UserPasswordPublicKeyFilePath))
                        throw new SorschiaException("User password public key file path is null or white-space");

                    instance
                        .AddSingleton(new UserPasswordPrivateKeyFilePathProvider(dependencySettings.UserPasswordPrivateKeyFilePath))
                        .AddSingleton(new UserPasswordPublicKeyFilePathProvider(dependencySettings.UserPasswordPublicKeyFilePath))
                        .AddSingleton<IUserPasswordPrivateKeyReader, UserPasswordPrivateKeyFileReader>()
                        .AddSingleton<IUserPasswordPrivateKeyWriter, UserPasswordPrivateKeyFileWriter>()
                        .AddSingleton<IUserPasswordPublicKeyReader, UserPasswordPublicKeyFileReader>()
                        .AddSingleton<IUserPasswordPublicKeyWriter, UserPasswordPublicKeyFileWriter>();
                    break;
            }

            if (dependencySettings.UseDefaultUserPasswordCryptors)
                instance
                    .AddSingleton<IUserPasswordDecryptor, UserPasswordDecryptor>()
                    .AddSingleton<IUserPasswordEncryptor, UserPasswordEncryptor>();

            if (dependencySettings.UseDefaultConfiguration)
            {
                var configuration = new SystemCoreConfiguration();
                dependencySettings.ConfigureConfiguration?.Invoke(configuration);
                instance.AddSingleton(configuration);
            }

            instance
                .AddSingleton<IUserPasswordPrivateKeyProvider, UserPasswordPrivateKeyProvider>()
                .AddSingleton<IUserPasswordPublicKeyProvider, UserPasswordPublicKeyProvider>();

            return instance;
        }
    }
}
