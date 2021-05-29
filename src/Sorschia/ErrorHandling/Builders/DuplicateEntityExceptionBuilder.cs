using Sorschia.Entities;
using System.Collections.Generic;

namespace Sorschia.ErrorHandling.Builders
{
    public sealed class DuplicateEntityExceptionBuilder : DuplicateEntityExceptionBuilderBase<DuplicateEntityExceptionBuilder>, IExceptionBuilder<DuplicateEntityException>
    {
        protected override DuplicateEntityExceptionBuilder Self => this;

        public DuplicateEntityException Build() => new(Message, InnerException, DebugMessage, EntityType, Fields);
    }

    public abstract class DuplicateEntityExceptionBuilderBase<TSelf> : EntityExceptionBuilderBase<TSelf>
    {
        public List<EntityField> Fields { get; } = new();

        public virtual TSelf AddField(EntityField field)
        {
            Fields.Add(field);
            return Self;
        }

        public virtual TSelf AddField(string name, object value = null) => AddField(new(name, value));
    }
}
