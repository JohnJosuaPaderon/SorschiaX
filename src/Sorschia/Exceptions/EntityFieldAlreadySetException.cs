using System;

namespace Sorschia.Exceptions
{
    public class EntityFieldAlreadySetException : EntityException
    {
        public EntityField? Field { get; }

        public EntityFieldAlreadySetException(string? message, Exception? innerException, string? debugMessage, Type? entityType, EntityField? field) : base(message, innerException, debugMessage, entityType)
        {
            Field = field;
        }
    }
}
