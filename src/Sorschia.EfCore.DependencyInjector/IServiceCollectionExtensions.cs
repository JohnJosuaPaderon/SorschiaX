using Microsoft.Extensions.DependencyInjection;
using Sorschia.Data;
using System;

namespace Sorschia
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddSorschiaEfCore(this IServiceCollection instance, Action<SorschiaEfCoreOptions> configure = null)
        {
            var options = new SorschiaEfCoreOptions();
            configure?.Invoke(options);

            instance.AddSingleton(options.Data ?? new DataOptions());

            return instance;
        }
    }
}
