using Microsoft.Extensions.DependencyInjection;
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
                        .AddSingleton<IPermissionTypeRepository, PermissionTypeRepository>()
                        .AddSingleton<IPlatformRepository, PlatformRepository>()
                        .AddSingleton<IUserRepository, UserRepository>();
                    break;
                case RepositoryOption.Cached:
                    instance
                        .AddSingleton<IApplicationRepository, ApplicationCachedRepository>()
                        .AddSingleton<IModuleRepository, ModuleCachedRepository>()
                        .AddSingleton<IPermissionRepository, PermissionCachedRepository>()
                        .AddSingleton<IPermissionGroupRepository, PermissionGroupCachedRepository>()
                        .AddSingleton<IPermissionTypeRepository, PermissionTypeCachedRepository>()
                        .AddSingleton<IPlatformRepository, PlatformCachedRepository>()
                        .AddSingleton<IUserRepository, UserCachedRepository>();
                    break;
            }

            if (dependencySettings.UseDefaultUserPasswordCryptors)
                instance
                    .AddSingleton<IUserPasswordDecryptor, UserPasswordDecryptor>()
                    .AddSingleton<IUserPasswordEncryptor, UserPasswordEncryptor>();

            return instance;
        }
    }
}
