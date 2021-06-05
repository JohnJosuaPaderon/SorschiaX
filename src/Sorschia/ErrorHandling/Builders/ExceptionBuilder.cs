using System;

namespace Sorschia.ErrorHandling.Builders
{
    public sealed class ExceptionBuilder : ExceptionBuilderBase<ExceptionBuilder>, IExceptionBuilder<Exception>
    {
        protected override ExceptionBuilder Self => this;

        public Exception Build() => new(Message, InnerException);
    }

    public abstract class ExceptionBuilderBase<TSelf>
    {
        public string Message { get; protected set; }
        public Exception InnerException { get; protected set; }

        protected abstract TSelf Self { get; }

        public virtual TSelf WithMessage(string message)
        {
            Message = message;
            return Self;
        }

        public virtual TSelf WithInnerException(Exception exception)
        {
            InnerException = exception;
            return Self;
        }

        public virtual TSelf WithMessage() => WithMessage("An internal error occured");
    }
}
