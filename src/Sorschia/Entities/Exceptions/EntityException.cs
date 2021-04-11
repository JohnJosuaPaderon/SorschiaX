using Sorschia.Exceptions;
using System;

namespace Sorschia.Entities.Exceptions
{
    public class EntityException : SorschiaException
    {
        public Type EntityType { get; }

        public EntityException(string message, Exception innerException, string userFriendlyMessage, Type entityType) : base(message, innerException, userFriendlyMessage)
        {
            EntityType = entityType;
        }
    }
}
