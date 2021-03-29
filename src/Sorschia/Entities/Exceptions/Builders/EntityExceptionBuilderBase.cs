using Sorschia.Exceptions.Builders;
using System;

namespace Sorschia.Entities.Exceptions.Builders
{
    public abstract class EntityExceptionBuilderBase<TInstance, TException> : SorschiaExceptionBuilderBase<TInstance, TException> where TException : EntityException
    {
        public Type? EntityType { get; set; }

        public virtual TInstance WithEntityType(Type entityType)
        {
            EntityType = entityType;
            return GetInstance();
        }

        public TInstance WithEntityType<TEntity>() => WithEntityType(typeof(TEntity));
    }
}
