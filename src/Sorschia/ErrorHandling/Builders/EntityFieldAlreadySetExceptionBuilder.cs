using Sorschia.Entities;

namespace Sorschia.ErrorHandling.Builders
{
    public sealed class EntityFieldAlreadySetExceptionBuilder : EntityFieldAlreadySetExceptionBuilderBase<EntityFieldAlreadySetExceptionBuilder>, IExceptionBuilder<EntityFieldAlreadySetException>
    {
        protected override EntityFieldAlreadySetExceptionBuilder Self => this;

        public EntityFieldAlreadySetException Build() => new(Message, InnerException, DebugMessage, EntityType, Field);
    }

    public abstract class EntityFieldAlreadySetExceptionBuilderBase<TSelf> : EntityExceptionBuilderBase<TSelf>
    {
        public EntityField Field { get; protected set; }

        public virtual TSelf WithField(EntityField field)
        {
            Field = field;
            return Self;
        }

        public virtual TSelf WithField(string name, object value = null) => WithField(new(name, value));
    }
}
