using Sorschia.Exceptions;
using System;

namespace Sorschia.Entities.Exceptions
{
    public class EntityException : SorschiaException
    {
        public Type? EntityType { get; }

        public EntityException(Type? entityType, bool isUserFriendlyMessage = false) : base(isUserFriendlyMessage)
        {
            EntityType = entityType;
        }

        public EntityException(Type? entityType, string? message, bool isUserFriendlyMessage = false) : base(message, isUserFriendlyMessage)
        {
            EntityType = entityType;
        }

        public EntityException(Type? entityType, string? message, Exception? innerException, bool isUserFriendlyMessage = false) : base(message, innerException, isUserFriendlyMessage)
        {
            EntityType = entityType;
        }
    }
}
