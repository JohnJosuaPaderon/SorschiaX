using System.Collections.Generic;

namespace Sorschia.Entities.Exceptions.Builders
{
    public sealed class DuplicateEntityFieldExceptionBuilder : EntityExceptionBuilderBase<DuplicateEntityFieldExceptionBuilder, DuplicateEntityFieldException>
    {
        public IDictionary<string, object> Fields { get; } = new Dictionary<string, object>();

        public override DuplicateEntityFieldException Build()
        {
            return new DuplicateEntityFieldException(EntityType, Fields, Message, InnerException, IsUserFriendlyMessage);
        }

        protected override DuplicateEntityFieldExceptionBuilder GetInstance() => this;

        public DuplicateEntityFieldExceptionBuilder AddField(string key, object value)
        {
            Fields.Add(key, value);
            return GetInstance();
        }
    }
}
