using System;
using Microsoft.Extensions.DependencyInjection;

namespace Sorschia
{
    internal sealed class DependencyProvider : IDependencyProvider
    {
        public DependencyProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        private readonly IServiceProvider _serviceProvider;

        public T Get<T>()
        {
            return _serviceProvider.GetService<T>();
        }
    }
}
