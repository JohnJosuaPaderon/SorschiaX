using System.Collections.Generic;

namespace Sorschia.Entities.Exceptions.Builders
{
    public abstract class DuplicateEntityFieldsExceptionBuilderBase<TSelf, TException> : EntityExceptionBuilderBase<TSelf, TException> where TException : DuplicateEntityFieldsException
    {
        public IDictionary<string, object> Fields { get; } = new Dictionary<string, object>();

        public virtual TSelf AddField(string name, object value)
        {
            Fields.Add(name, value);
            return Self;
        }

        public virtual TSelf AddField(KeyValuePair<string, object> field)
        {
            Fields.Add(field);
            return Self;
        }
    }
}
