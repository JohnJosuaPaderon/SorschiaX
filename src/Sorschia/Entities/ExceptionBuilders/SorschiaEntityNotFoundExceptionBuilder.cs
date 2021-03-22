using System;
using System.Collections.Generic;

namespace Sorschia.Entities.ExceptionBuilders
{
    public sealed class SorschiaEntityNotFoundExceptionBuilder
    {
        public Type? EntityType { get; private set; }
        public IDictionary<string, object> LookupFields { get; } = new Dictionary<string, object>();

        public SorschiaEntityNotFoundExceptionBuilder WithEntityType(Type entityType)
        {
            EntityType = entityType;
            return this;
        }

        public SorschiaEntityNotFoundExceptionBuilder WithEntityType<T>()
        {
            WithEntityType(typeof(T));
            return this;
        }

        public SorschiaEntityNotFoundExceptionBuilder AddLookupField(string key, object value)
        {
            LookupFields.Add(key, value);
            return this;
        }

        public SorschiaEntityNotFoundException Build()
        {
            return new SorschiaEntityNotFoundException(EntityType, LookupFields);
        }
    }
}
