using System;
using System.Collections.Generic;

namespace Sorschia.Entities.Exceptions
{
    public class DuplicateEntityException : EntityException
    {
        public IEnumerable<KeyValuePair<string, object>> Fields { get; }

        public DuplicateEntityException(string message, Exception innerException, string userFriendlyMessage, Type entityType, IEnumerable<KeyValuePair<string, object>> fields) : base(message, innerException, userFriendlyMessage, entityType)
        {
            Fields = fields;
        }
    }
}
