using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Sorschia.Entities
{
    public class EntityFieldAlreadySetException : EntityException
    {
        public IDictionary<string, object> EntityFields { get; }

        public EntityFieldAlreadySetException(Type? entityType, IDictionary<string, object> entityFields, bool isUserFriendlyMessage = false) : base(entityType, isUserFriendlyMessage)
        {
            EntityFields = entityFields;
        }

        public EntityFieldAlreadySetException(Type? entityType, IDictionary<string, object> entityFields, string message, bool isUserFriendlyMessage = false) : base(entityType, message, isUserFriendlyMessage)
        {
            EntityFields = entityFields;
        }

        public EntityFieldAlreadySetException(Type? entityType, IDictionary<string, object> entityFields, string message, Exception innerException, bool isUserFriendlyMessage = false) : base(entityType, message, innerException, isUserFriendlyMessage)
        {
            EntityFields = entityFields;
        }

        protected EntityFieldAlreadySetException(Type? entityType, IDictionary<string, object> entityFields, SerializationInfo info, StreamingContext context, bool isUserFriendlyMessage = false) : base(entityType, info, context, isUserFriendlyMessage)
        {
            EntityFields = entityFields;
        }
    }
}
