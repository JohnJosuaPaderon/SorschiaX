using System;

namespace Sorschia.Exceptions.Builders
{
    public abstract class ExceptionBuilderBase<TInstance, TException> where TException : Exception
    {
        public string? Message { get; protected set; }
        public Exception? InnerException { get; protected set; }

        protected abstract TInstance GetInstance();

        public abstract TException Build();

        public virtual TInstance WithMessage(string message)
        {
            Message = message;
            return GetInstance();
        }

        public virtual TInstance WithInnerException(Exception innerException)
        {
            InnerException = innerException;
            return GetInstance();
        }
    }
}
