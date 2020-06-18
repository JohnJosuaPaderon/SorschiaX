using Microsoft.Extensions.DependencyInjection;
using System;

namespace Sorschia.Utilities
{
    internal sealed class DependencyResolver : IDependencyResolver
    {
        private readonly IServiceProvider _serviceProvider;

        public DependencyResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T Resolve<T>() => _serviceProvider.GetService<T>();
    }
}
