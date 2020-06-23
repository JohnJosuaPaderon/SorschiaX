using Microsoft.Extensions.DependencyInjection;
using Sorschia.Security;
using Sorschia.Utilities;
using System;

namespace Sorschia
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSorschia(this IServiceCollection instance, Action<DependencySettings> configureSettings = null)
        {
            var dependencySettings = new DependencySettings();

            configureSettings?.Invoke(dependencySettings);

            return instance
                .AddSecurity(dependencySettings.Security)
                .AddUtilities(dependencySettings.Utilities);
        }
    }
}
