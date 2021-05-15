using System;

namespace Sorschia.Exceptions
{
    public class EntityException : SorschiaException
    {
        public Type? EntityType { get; }

        public EntityException(string? message, Exception? innerException, string? debugMessage, Type? entityType) : base(message, innerException, debugMessage)
        {
            EntityType = entityType;
        }
    }
}
