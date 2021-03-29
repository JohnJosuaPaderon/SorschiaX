using System;
using System.Collections.Generic;

namespace Sorschia.Entities.ExceptionBuilders
{
    public sealed class EntityFieldAlreadySetExceptionBuilder
    {
        public Type? EntityType { get; private set; }
        public IDictionary<string, object> EntityFields { get; } = new Dictionary<string, object>();

        public EntityFieldAlreadySetExceptionBuilder WithEntityType(Type entityType)
        {
            EntityType = entityType;
            return this;
        }

        public EntityFieldAlreadySetExceptionBuilder WithEntityType<T>()
        {
            WithEntityType(typeof(T));
            return this;
        }

        public EntityFieldAlreadySetExceptionBuilder AddEntityField(string key, object value)
        {
            EntityFields.Add(key, value);
            return this;
        }

        public EntityFieldAlreadySetException Build()
        {
            return new EntityFieldAlreadySetException(EntityType, EntityFields);
        }
    }
}
