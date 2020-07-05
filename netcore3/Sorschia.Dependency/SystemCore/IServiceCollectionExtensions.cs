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

            switch (dependencySettings.RepositoryOption)
            {
                case RepositoryOption.Regular:
                    instance
                        .AddSingleton<IApplicationRepository, ApplicationRepository>()
                        .AddSingleton<IModuleRepository, ModuleRepository>()
                        .AddSingleton<IPermissionRepository, PermissionRepository>()
                        .AddSingleton<IPermissionGroupRepository, PermissionGroupRepository>();
                    break;
                case RepositoryOption.Cached:
                    instance
                        .AddSingleton<IApplicationRepository, ApplicationCachedRepository>()
                        .AddSingleton<IModuleRepository, ModuleCachedRepository>()
                        .AddSingleton<IPermissionRepository, PermissionCachedRepository>()
                        .AddSingleton<IPermissionGroupRepository, PermissionGroupCachedRepository>();
                    break;
            }

            return instance;
        }
    }
}
