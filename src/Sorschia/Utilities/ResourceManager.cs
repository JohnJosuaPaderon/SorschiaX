using Sorschia.ErrorHandling.Builders;
using System;
using System.Collections.Generic;

namespace Sorschia.Utilities
{
    internal sealed class ResourceManager : IResourceManager
    {
        private readonly object _lockObj = new();
        private readonly Dictionary<Guid, ResourceContext> _contexts = new();
        private readonly Dictionary<Guid, Guid> _attachments = new();

        public void Attach(IResourceContext context, IResourceConsumer consumer)
        {
            lock (_lockObj)
            {
                if (context is not ResourceContext concrete)
                    throw new SorschiaExceptionBuilder()
                        .WithMessage()
                        .WithDebugMessage($"Context is not of type {typeof(ResourceContext).FullName}")
                        .Build();

                consumer.Id.NewInternalId();

                while (_attachments.ContainsKey(consumer.Id.InternalId))
                    consumer.Id.NewInternalId();

                _attachments.Add(consumer.Id, concrete.Id);
            }
        }

        public IResourceContext CreateContext()
        {
            lock (_lockObj)
            {
                var id = Guid.NewGuid();

                while (_contexts.ContainsKey(id))
                    id = Guid.NewGuid();

                var context = new ResourceContext(this, id);
                _contexts.Add(id, context);
                return context;
            }
        }

        public void Dispose(IResourceContext context)
        {
            lock (_lockObj)
            {
                if (context is not ResourceContext concrete)
                    throw new SorschiaExceptionBuilder()
                        .WithMessage()
                        .WithDebugMessage($"Context is not of type {typeof(ResourceContext).FullName}")
                        .Build();

                _contexts.Remove(concrete.Id);

                for (int i = 0; i < concrete.ConsumerIds.Count; i++)
                {
                    if (_attachments.ContainsKey(concrete.ConsumerIds[i]))
                        _attachments.Remove(concrete.ConsumerIds[i]);
                }
            }
        }

        public IResourceContext GetContext(IResourceConsumer consumer)
        {
            lock (_lockObj)
            {
                if (!_attachments.ContainsKey(consumer.Id))
                    throw new SorschiaExceptionBuilder()
                        .WithMessage()
                        .WithDebugMessage("Consumer is not attached to any context")
                        .Build();

                var contextId = _attachments[consumer.Id];

                if (!_contexts.ContainsKey(contextId))
                    throw new SorschiaExceptionBuilder()
                        .WithMessage()
                        .WithDebugMessage($"Context with Id = ${contextId} does not exists")
                        .Build();

                return _contexts[contextId];
            }
        }
    }
}
