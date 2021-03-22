using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Sorschia.Entities
{
    public class SorschiaDuplicateEntityFieldException : SorschiaEntityException
    {
        public IDictionary<string, object> DuplicatedFields { get; }

        public SorschiaDuplicateEntityFieldException(Type? entityType, IDictionary<string, object> duplicateFields, bool isUserFriendlyMessage = false) : base(entityType, isUserFriendlyMessage)
        {
            DuplicatedFields = duplicateFields;
        }

        public SorschiaDuplicateEntityFieldException(Type? entityType, IDictionary<string, object> duplicateFields, string message, bool isUserFriendlyMessage = false) : base(entityType, message, isUserFriendlyMessage)
        {
            DuplicatedFields = duplicateFields;
        }

        public SorschiaDuplicateEntityFieldException(Type? entityType, IDictionary<string, object> duplicateFields, string message, Exception innerException, bool isUserFriendlyMessage = false) : base(entityType, message, innerException, isUserFriendlyMessage)
        {
            DuplicatedFields = duplicateFields;
        }

        protected SorschiaDuplicateEntityFieldException(Type? entityType, IDictionary<string, object> duplicateFields, SerializationInfo info, StreamingContext context, bool isUserFriendlyMessage = false) : base(entityType, info, context, isUserFriendlyMessage)
        {
            DuplicatedFields = duplicateFields;
        }
    }
}
