using System;
using System.Runtime.Serialization;

namespace Sorschia.Entities
{
    public class SorschiaEntityException : SorschiaException
    {
        public Type? EntityType { get; }

        public SorschiaEntityException(Type? entityType, bool isUserFriendlyMessage = false) : base(isUserFriendlyMessage)
        {
            EntityType = entityType;
        }

        public SorschiaEntityException(Type? entityType, string message, bool isUserFriendlyMessage = false) : base(message, isUserFriendlyMessage)
        {
            EntityType = entityType;
        }

        public SorschiaEntityException(Type? entityType, string message, Exception innerException, bool isUserFriendlyMessage = false) : base(message, innerException, isUserFriendlyMessage)
        {
            EntityType = entityType;
        }

        protected SorschiaEntityException(Type? entityType, SerializationInfo info, StreamingContext context, bool isUserFriendlyMessage = false) : base(info, context, isUserFriendlyMessage)
        {
            EntityType = entityType;
        }
    }
}
