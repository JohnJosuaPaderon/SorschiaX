using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Sorschia
{
    public class SorschiaEntityNotFoundException : SorschiaException
    {
        public Type? EntityType { get; }
        public IDictionary<string, object> LookupParameters { get; }

        public SorschiaEntityNotFoundException(Type? entityType, IDictionary<string, object> lookupParameters, bool isUserFriendlyMessage = false) : base(isUserFriendlyMessage)
        {
            EntityType = entityType;
            LookupParameters = lookupParameters;
        }

        public SorschiaEntityNotFoundException(Type? entityType, IDictionary<string, object> lookupParameters, string message, bool isUserFriendlyMessage = false) : base(message, isUserFriendlyMessage)
        {
            EntityType = entityType;
            LookupParameters = lookupParameters;
        }

        public SorschiaEntityNotFoundException(Type? entityType, IDictionary<string, object> lookupParameters, string message, Exception innerException, bool isUserFriendlyMessage = false) : base(message, innerException, isUserFriendlyMessage)
        {
            EntityType = entityType;
            LookupParameters = lookupParameters;
        }

        protected SorschiaEntityNotFoundException(Type? entityType, IDictionary<string, object> lookupParameters, SerializationInfo info, StreamingContext context, bool isUserFriendlyMessage = false) : base(info, context, isUserFriendlyMessage)
        {
            EntityType = entityType;
            LookupParameters = lookupParameters;
        }
    }
}
