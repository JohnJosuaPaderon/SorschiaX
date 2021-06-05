using Sorschia.ErrorHandling.Builders;
using System;
using System.Collections.Generic;

namespace Sorschia.Utilities
{
    internal sealed class ResourceContext : IResourceContext
    {
        private readonly object _lockObj = new();
        private readonly Dictionary<string, object> _resources = new();
        private readonly List<Guid> _consumerIds = new();
        private readonly IResourceManager _manager;
        private readonly Guid _id;

        public Guid Id => _id;
        public List<Guid> ConsumerIds => _consumerIds;

        public ResourceContext(IResourceManager manager, Guid id)
        {
            _manager = manager;
            _id = id;
        }

        public IResourceContext AttachConsumer(IResourceConsumer consumer)
        {
            _consumerIds.Add(consumer.Id);
            _manager.Attach(this, consumer);
            return this;
        }

        public TResource Request<TResource>(string name)
        {
            lock (_lockObj)
            {
                if (_resources.ContainsKey(name) && _resources[name] is TResource resource)
                    return resource;

                throw new SorschiaExceptionBuilder()
                    .WithMessage()
                    .WithDebugMessage($"Resource of type {typeof(TResource).FullName} with Name = {name} does not exists")
                    .Build();
            }
        }

        public IResourceContext Register(string name, object resource)
        {
            lock (_lockObj)
            {
                if (_resources.ContainsKey(name))
                    _resources[name] = resource;
                else
                    _resources.Add(name, resource);

                return this;
            }
        }

        public void Dispose()
        {
            _manager.Dispose(this);
        }
    }
}
