using System;
using System.Collections.Generic;

namespace Sorschia.Entities.ExceptionBuilders
{
    public sealed class DuplicateEntityFieldExceptionBuilder
    {
        public Type? EntityType { get; private set; }
        public IDictionary<string, object> DuplicateFields { get; } = new Dictionary<string, object>();

        public DuplicateEntityFieldExceptionBuilder WithEntityType(Type entityType)
        {
            EntityType = entityType;
            return this;
        }

        public DuplicateEntityFieldExceptionBuilder WithEntityType<T>()
        {
            WithEntityType(typeof(T));
            return this;
        }

        public DuplicateEntityFieldExceptionBuilder AddDuplicateField(string key, object value)
        {
            DuplicateFields.Add(key, value);
            return this;
        }

        public DuplicateEntityFieldException Build()
        {
            return new DuplicateEntityFieldException(EntityType, DuplicateFields);
        }
    }
}
