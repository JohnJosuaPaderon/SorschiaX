using System;
using System.Collections.Generic;

namespace Sorschia.Entities.ExceptionBuilders
{
    public sealed class SorschiaEntityFieldAlreadySetExceptionBuilder
    {
        public Type? EntityType { get; private set; }
        public IDictionary<string, object> EntityFields { get; } = new Dictionary<string, object>();

        public SorschiaEntityFieldAlreadySetExceptionBuilder WithEntityType(Type entityType)
        {
            EntityType = entityType;
            return this;
        }

        public SorschiaEntityFieldAlreadySetExceptionBuilder WithEntityType<T>()
        {
            WithEntityType(typeof(T));
            return this;
        }

        public SorschiaEntityFieldAlreadySetExceptionBuilder AddEntityField(string key, object value)
        {
            EntityFields.Add(key, value);
            return this;
        }

        public SorschiaEntityFieldAlreadySetException Build()
        {
            return new SorschiaEntityFieldAlreadySetException(EntityType, EntityFields);
        }
    }
}
