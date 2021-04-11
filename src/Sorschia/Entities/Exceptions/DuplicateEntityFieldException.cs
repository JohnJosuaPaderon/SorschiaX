using System;

namespace Sorschia.Entities.Exceptions
{
    public class DuplicateEntityFieldException : EntityException
    {
        public string FieldName { get; }
        public object FieldValue { get; }

        public DuplicateEntityFieldException(string message, Exception innerException, string userFriendlyMessage, Type entityType, string fieldName, object fieldValue) : base(message, innerException, userFriendlyMessage, entityType)
        {
            FieldName = fieldName;
            FieldValue = fieldValue;
        }
    }
}
