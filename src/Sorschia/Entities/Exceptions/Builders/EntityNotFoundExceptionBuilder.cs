using System;
using System.Collections.Generic;

namespace Sorschia.Entities.Exceptions.Builders
{
    public sealed class EntityNotFoundExceptionBuilder
    {
        public Type? EntityType { get; private set; }
        public IDictionary<string, object> LookupFields { get; } = new Dictionary<string, object>();

        public EntityNotFoundExceptionBuilder WithEntityType(Type entityType)
        {
            EntityType = entityType;
            return this;
        }

        public EntityNotFoundExceptionBuilder WithEntityType<T>()
        {
            WithEntityType(typeof(T));
            return this;
        }

        public EntityNotFoundExceptionBuilder AddLookupField(string key, object value)
        {
            LookupFields.Add(key, value);
            return this;
        }

        public EntityNotFoundException Build()
        {
            return new EntityNotFoundException(EntityType, LookupFields);
        }
    }
}
