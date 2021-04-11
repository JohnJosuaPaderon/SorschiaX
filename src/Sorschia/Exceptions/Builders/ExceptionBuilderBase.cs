using System;

namespace Sorschia.Exceptions.Builders
{
    public abstract class ExceptionBuilderBase<TSelf, TException> where TException : Exception
    {
        public string Message { get; protected set; }
        public Exception InnerException { get; protected set; }

        protected abstract TSelf Self { get; }

        public abstract TException Build();

        public virtual TSelf WithMessage(string message)
        {
            Message = message;
            return Self;
        }

        public virtual TSelf WithInnerException(Exception innerException)
        {
            InnerException = innerException;
            return Self;
        }
    }
}
