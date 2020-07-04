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
                        .AddSingleton<IModuleRepository, ModuleRepository>();
                    break;
                case RepositoryOption.Cached:
                    instance
                        .AddSingleton<IApplicationRepository, ApplicationCachedRepository>()
                        .AddSingleton<IModuleRepository, ModuleCachedRepository>();
                    break;
            }

            return instance;
        }
    }
}
