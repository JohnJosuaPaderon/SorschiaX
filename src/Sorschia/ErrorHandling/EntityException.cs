using System;

namespace Sorschia.ErrorHandling
{
    public class EntityException : SorschiaException
    {
        public Type EntityType { get; }

        public EntityException()
        {
        }

        public EntityException(string message, Exception innerException, string debugMessage, Type entityType) : base(message, innerException, debugMessage)
        {
            EntityType = entityType;
        }
    }
}
