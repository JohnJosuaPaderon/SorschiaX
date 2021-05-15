using System;

namespace Sorschia.Exceptions.Builders
{
    public sealed class EntityExceptionBuilder : EntityExceptionBuilderBase<EntityExceptionBuilder>, IExceptionBuilder<EntityException>
    {
        protected override EntityExceptionBuilder Self => this;

        public EntityException Build() => new(Message, InnerException, DebugMessage, EntityType);
    }

    public abstract class EntityExceptionBuilderBase<TSelf> : SorschiaExceptionBuilderBase<TSelf>
    {
        public Type? EntityType { get; protected set; }

        public virtual TSelf WithEntityType(Type entityType)
        {
            EntityType = entityType;
            return Self;
        }

        public TSelf WithEntityType<TEntity>() => WithEntityType(typeof(TEntity));
    }
}
