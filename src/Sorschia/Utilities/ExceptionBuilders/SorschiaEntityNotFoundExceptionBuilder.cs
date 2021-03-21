using System;
using System.Collections.Generic;

namespace Sorschia.Utilities.ExceptionBuilders
{
    public sealed class SorschiaEntityNotFoundExceptionBuilder
    {
        public Type? EntityType { get; private set; }
        public IDictionary<string, object> LookupParameters { get; } = new Dictionary<string, object>();

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

        public SorschiaEntityNotFoundExceptionBuilder AddLookupParameter(string key, object value)
        {
            LookupParameters.Add(key, value);
            return this;
        }

        public SorschiaEntityNotFoundException Build()
        {
            return new SorschiaEntityNotFoundException(EntityType, LookupParameters);
        }
    }
}
