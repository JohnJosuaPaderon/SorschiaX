using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Sorschia
{
    public class SorschiaEntityFieldAlreadySetException : SorschiaException
    {
        public Type? EntityType { get; }
        public IDictionary<string, object> EntityFields { get; }

        public SorschiaEntityFieldAlreadySetException(Type? entityType, IDictionary<string, object> entityFields, bool isUserFriendlyMessage = false) : base(isUserFriendlyMessage)
        {
            EntityType = entityType;
            EntityFields = entityFields;
        }

        public SorschiaEntityFieldAlreadySetException(Type? entityType, IDictionary<string, object> entityFields, string message, bool isUserFriendlyMessage = false) : base(message, isUserFriendlyMessage)
        {
            EntityType = entityType;
            EntityFields = entityFields;
        }

        public SorschiaEntityFieldAlreadySetException(Type? entityType, IDictionary<string, object> entityFields, string message, Exception innerException, bool isUserFriendlyMessage = false) : base(message, innerException, isUserFriendlyMessage)
        {
            EntityType = entityType;
            EntityFields = entityFields;
        }

        protected SorschiaEntityFieldAlreadySetException(Type? entityType, IDictionary<string, object> entityFields, SerializationInfo info, StreamingContext context, bool isUserFriendlyMessage = false) : base(info, context, isUserFriendlyMessage)
        {
            EntityType = entityType;
            EntityFields = entityFields;
        }
    }
}
