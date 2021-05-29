using Sorschia.Entities;
using System;
using System.Collections.Generic;

namespace Sorschia.ErrorHandling
{
    public class DuplicateEntityException : EntityException
    {
        public IEnumerable<EntityField> Fields { get; }

        public DuplicateEntityException()
        {
        }

        public DuplicateEntityException(string message, Exception innerException, string debugMessage, Type entityType, IEnumerable<EntityField> fields) : base(message, innerException, debugMessage, entityType)
        {
            Fields = fields;
        }
    }
}
