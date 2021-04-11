using Sorschia.Exceptions.Builders;
using System;

namespace Sorschia.Data.Exceptions.Builders
{
    public abstract class InvalidDbContextExceptionBuilderBase<TSelf, TException> : SorschiaExceptionBuilderBase<TSelf, TException> where TException : InvalidDbContextException
    {
        public Type DbContextType { get; protected set; }

        public virtual TSelf WithDbContextType(Type dbContextType)
        {
            DbContextType = dbContextType;
            return Self;
        }

        public TSelf WithDbContextType<TDbContext>()
        {
            return WithDbContextType(typeof(TDbContext));
        }
    }
}
