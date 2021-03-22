using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Sorschia.Entities
{
    public class SorschiaEntityNotFoundException : SorschiaEntityException
    {
        public IDictionary<string, object> LookupFields { get; }

        public SorschiaEntityNotFoundException(Type? entityType, IDictionary<string, object> lookupFields, bool isUserFriendlyMessage = false) : base(entityType, isUserFriendlyMessage)
        {
            LookupFields = lookupFields;
        }

        public SorschiaEntityNotFoundException(Type? entityType, IDictionary<string, object> lookupFields, string message, bool isUserFriendlyMessage = false) : base(entityType, message, isUserFriendlyMessage)
        {
            LookupFields = lookupFields;
        }

        public SorschiaEntityNotFoundException(Type? entityType, IDictionary<string, object> lookupFields, string message, Exception innerException, bool isUserFriendlyMessage = false) : base(entityType, message, innerException, isUserFriendlyMessage)
        {
            LookupFields = lookupFields;
        }

        protected SorschiaEntityNotFoundException(Type? entityType, IDictionary<string, object> lookupFields, SerializationInfo info, StreamingContext context, bool isUserFriendlyMessage = false) : base(entityType, info, context, isUserFriendlyMessage)
        {
            LookupFields = lookupFields;
        }
    }
}
