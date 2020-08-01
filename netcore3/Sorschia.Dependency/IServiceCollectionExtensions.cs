using Microsoft.Extensions.DependencyInjection;
using Sorschia.Data;
using Sorschia.Security;
using Sorschia.SystemCore;
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
                .AddData(dependencySettings.Data)
                .AddSecurity(dependencySettings.Security)
                .AddSystemCore(dependencySettings.SystemCore)
                .AddUtilities(dependencySettings.Utilities);
        }
    }
}
