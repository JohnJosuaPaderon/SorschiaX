using Microsoft.Extensions.DependencyInjection;
using System;

namespace Sorschia.Utilities
{
    internal static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddUtilities(this IServiceCollection instance, UtilitiesDependencySettings dependencySettings)
        {
            if (dependencySettings == null)
                throw SorschiaException.DependencySettingsIsNull<UtilitiesDependencySettings>();

            if (dependencySettings.UseDependencyResolver)
                instance.AddSingleton<IDependencyResolver, DependencyResolver>();

            if (dependencySettings.UseDefaultFullNameBuilder)
                instance.AddSingleton<IFullNameBuilder, FullNameBuilder>();

            return instance;
        }
    }
}
