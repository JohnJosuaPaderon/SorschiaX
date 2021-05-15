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
}
