using Sorschia.Exceptions.Builders;
using System;

namespace Sorschia.Entities.Exceptions.Builders
{
    public abstract class EntityExceptionBuilderBase<TSelf, TException> : SorschiaExceptionBuilderBase<TSelf, TException> where TException : EntityException
    {
        public Type EntityType { get; protected set; }

        public virtual TSelf WithEntityType(Type entityType)
        {
            EntityType = entityType;
            return Self;
        }

        public TSelf WithEntityType<TEntity>()
        {
            return WithEntityType(typeof(TEntity));
        }
    }
}
