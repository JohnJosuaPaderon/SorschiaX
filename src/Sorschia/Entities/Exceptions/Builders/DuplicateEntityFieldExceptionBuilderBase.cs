namespace Sorschia.Entities.Exceptions.Builders
{
    public abstract class DuplicateEntityFieldExceptionBuilderBase<TSelf, TException> : EntityExceptionBuilderBase<TSelf, TException> where TException : DuplicateEntityFieldException
    {
        public string FieldName { get; protected set; }
        public object FieldValue { get; protected set; }

        public virtual TSelf WithFieldName(string name)
        {
            FieldName = name;
            return Self;
        }

        public virtual TSelf WithField(string name, object value)
        {
            FieldName = name;
            FieldValue = value;
            return Self;
        }
    }
}
