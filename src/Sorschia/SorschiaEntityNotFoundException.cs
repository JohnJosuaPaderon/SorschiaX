using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Sorschia
{
    public class SorschiaEntityNotFoundException : SorschiaException
    {
        public Type? EntityType { get; }
        public IDictionary<string, object> LookupFields { get; }

        public SorschiaEntityNotFoundException(Type? entityType, IDictionary<string, object> lookupFields, bool isUserFriendlyMessage = false) : base(isUserFriendlyMessage)
        {
            EntityType = entityType;
            LookupFields = lookupFields;
        }

        public SorschiaEntityNotFoundException(Type? entityType, IDictionary<string, object> lookupFields, string message, bool isUserFriendlyMessage = false) : base(message, isUserFriendlyMessage)
        {
            EntityType = entityType;
            LookupFields = lookupFields;
        }

        public SorschiaEntityNotFoundException(Type? entityType, IDictionary<string, object> lookupFields, string message, Exception innerException, bool isUserFriendlyMessage = false) : base(message, innerException, isUserFriendlyMessage)
        {
            EntityType = entityType;
            LookupFields = lookupFields;
        }

        protected SorschiaEntityNotFoundException(Type? entityType, IDictionary<string, object> lookupFields, SerializationInfo info, StreamingContext context, bool isUserFriendlyMessage = false) : base(info, context, isUserFriendlyMessage)
        {
            EntityType = entityType;
            LookupFields = lookupFields;
        }
    }
}
