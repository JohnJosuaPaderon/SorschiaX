namespace Sorschia.Entities.Exceptions.Builders
{
    public abstract class EntityFieldAlreadySetExceptionBuilderBase<TSelf, TException> : EntityExceptionBuilderBase<TSelf, TException> where TException : EntityFieldAlreadySetException
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
