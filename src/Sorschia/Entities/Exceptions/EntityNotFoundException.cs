using System;
using System.Collections.Generic;

namespace Sorschia.Entities.Exceptions
{
    public class EntityNotFoundException : EntityException
    {
        public IDictionary<string, object>? Fields { get; }

        public EntityNotFoundException(Type? entityType, IDictionary<string, object>? fields, bool isUserFriendlyMessage = false) : base(entityType, isUserFriendlyMessage)
        {
            Fields = fields;
        }

        public EntityNotFoundException(Type? entityType, IDictionary<string, object>? fields, string? message, bool isUserFriendlyMessage = false) : base(entityType, message, isUserFriendlyMessage)
        {
            Fields = fields;
        }

        public EntityNotFoundException(Type? entityType, IDictionary<string, object>? fields, string? message, Exception? innerException, bool isUserFriendlyMessage = false) : base(entityType, message, innerException, isUserFriendlyMessage)
        {
            Fields = fields;
        }
    }
}
