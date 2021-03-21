using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Sorschia
{
    public class SorschiaDuplicateEntityFieldException : SorschiaException
    {
        public Type? EntityType { get; }
        public IDictionary<string, object> DuplicatedFields { get; }

        public SorschiaDuplicateEntityFieldException(Type? entityType, IDictionary<string, object> duplicateFields, bool isUserFriendlyMessage = false) : base(isUserFriendlyMessage)
        {
            EntityType = entityType;
            DuplicatedFields = duplicateFields;
        }

        public SorschiaDuplicateEntityFieldException(Type? entityType, IDictionary<string, object> duplicateFields, string message, bool isUserFriendlyMessage = false) : base(message, isUserFriendlyMessage)
        {
            EntityType = entityType;
            DuplicatedFields = duplicateFields;
        }

        public SorschiaDuplicateEntityFieldException(Type? entityType, IDictionary<string, object> duplicateFields, string message, Exception innerException, bool isUserFriendlyMessage = false) : base(message, innerException, isUserFriendlyMessage)
        {
            EntityType = entityType;
            DuplicatedFields = duplicateFields;
        }

        protected SorschiaDuplicateEntityFieldException(Type? entityType, IDictionary<string, object> duplicateFields, SerializationInfo info, StreamingContext context, bool isUserFriendlyMessage = false) : base(info, context, isUserFriendlyMessage)
        {
            EntityType = entityType;
            DuplicatedFields = duplicateFields;
        }
    }
}
