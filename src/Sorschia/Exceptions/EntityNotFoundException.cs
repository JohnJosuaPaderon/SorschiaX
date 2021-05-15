using System;
using System.Collections.Generic;

namespace Sorschia.Exceptions
{
    public class EntityNotFoundException : EntityException
    {
        public IEnumerable<EntityField>? Fields { get; }

        public EntityNotFoundException(string? message, Exception? innerException, string? debugMessage, Type? entityType, IEnumerable<EntityField>? fields) : base(message, innerException, debugMessage, entityType)
        {
            Fields = fields;
        }
    }
}
