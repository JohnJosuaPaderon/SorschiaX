using System;
using System.Collections.Generic;

namespace Sorschia.Exceptions
{
    public class DuplicateEntityException : EntityException
    {
        public IEnumerable<EntityField>? Fields { get; }

        public DuplicateEntityException(string? message, Exception? innerException, string? debugMessage, Type? entityType, IEnumerable<EntityField>? fields) : base(message, innerException, debugMessage, entityType)
        {
            Fields = fields;
        }
    }
}
