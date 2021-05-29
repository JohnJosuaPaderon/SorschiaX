using Sorschia.Entities;
using System.Collections.Generic;

namespace Sorschia.ErrorHandling.Builders
{
    public sealed class EntityNotFoundExceptionBuilder : EntityNotFoundExceptionBuilderBase<EntityNotFoundExceptionBuilder>, IExceptionBuilder<EntityNotFoundException>
    {
        protected override EntityNotFoundExceptionBuilder Self => this;

        public EntityNotFoundException Build() => new(Message, InnerException, DebugMessage, EntityType, Fields);
    }

    public abstract class EntityNotFoundExceptionBuilderBase<TSelf> : EntityExceptionBuilderBase<TSelf>
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
