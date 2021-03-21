using System;
using System.Collections.Generic;

namespace Sorschia.Utilities.ExceptionBuilders
{
    public sealed class SorschiaDuplicateEntityFieldExceptionBuilder
    {
        public Type? EntityType { get; private set; }
        public IDictionary<string, object> DuplicateFields { get; } = new Dictionary<string, object>();

        public SorschiaDuplicateEntityFieldExceptionBuilder WithEntityType(Type entityType)
        {
            EntityType = entityType;
            return this;
        }

        public SorschiaDuplicateEntityFieldExceptionBuilder WithEntityType<T>()
        {
            WithEntityType(typeof(T));
            return this;
        }

        public SorschiaDuplicateEntityFieldExceptionBuilder AddDuplicateFields(string key, object value)
        {
            DuplicateFields.Add(key, value);
            return this;
        }

        public SorschiaDuplicateEntityFieldException Build()
        {
            return new SorschiaDuplicateEntityFieldException(EntityType, DuplicateFields);
        }
    }
}
