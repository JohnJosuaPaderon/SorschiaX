using System;

namespace Sorschia.Exceptions.Builders
{
    /// <summary>
    /// An implementation of <see cref="IExceptionBuilder{TException}"/> to build an instance of <see cref="Exception"/>
    /// </summary>
    public sealed class ExceptionBuilder : ExceptionBuilderBase<ExceptionBuilder>, IExceptionBuilder<Exception>
    {
        protected override ExceptionBuilder Self => this;

        public Exception Build() => new(Message, InnerException);
    }

    /// <summary>
    /// Base class for building exceptions
    /// </summary>
    /// <typeparam name="TSelf">A type of class that derives from <see cref="ExceptionBuilderBase{TSelf}"/> class</typeparam>
    public abstract class ExceptionBuilderBase<TSelf>
    {
        /// <summary>
        /// The message that describes the exception.
        /// </summary>
        public string? Message { get; protected set; }
        /// <summary>
        /// The instance of <see cref="Exception"/> that caused the exception.
        /// </summary>
        public Exception? InnerException { get; protected set; }
        /// <summary>
        /// The instance of the current builder.
        /// </summary>
        protected abstract TSelf Self { get; }

        /// <summary>
        /// Sets the property <see cref="ExceptionBuilderBase{TSelf}.Message"/>
        /// </summary>
        /// <param name="message">A message that describes the exception</param>
        /// <returns>The current builder</returns>
        public virtual TSelf WithMessage(string message)
        {
            Message = message;
            return Self;
        }

        /// <summary>
        /// Sets the property <see cref="ExceptionBuilderBase{TSelf}.InnerException"/>
        /// </summary>
        /// <param name="innerException">An instance of <see cref="Exception"/> that caused the exception</param>
        /// <returns>The current builder</returns>
        public virtual TSelf WithInnerException(Exception innerException)
        {
            InnerException = innerException;
            return Self;
        }
    }
}
