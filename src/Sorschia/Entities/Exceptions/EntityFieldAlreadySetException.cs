using System;

namespace Sorschia.Entities.Exceptions
{
    public class EntityFieldAlreadySetException : EntityException
    {
        public string FieldName { get; }
        public object FieldValue { get; }

        public EntityFieldAlreadySetException(string message, Exception innerException, string userFriendlyMessage, Type entityType, string fieldName, object fieldValue) : base(message, innerException, userFriendlyMessage, entityType)
        {
            FieldName = fieldName;
            FieldValue = fieldValue;
        }
    }
}
