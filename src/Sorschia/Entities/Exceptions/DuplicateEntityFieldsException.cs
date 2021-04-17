using System;
using System.Collections.Generic;

namespace Sorschia.Entities.Exceptions
{
    public class DuplicateEntityFieldsException : EntityException
    {
        public IEnumerable<KeyValuePair<string, object>> Fields { get; }

        public DuplicateEntityFieldsException(string message, Exception innerException, string userFriendlyMessage, Type entityType, IEnumerable<KeyValuePair<string, object>> fields) : base(message, innerException, userFriendlyMessage, entityType)
        {
            Fields = fields;
        }
    }
}
