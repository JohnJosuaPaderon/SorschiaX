using System;

namespace Sorschia.Exceptions.Builders
{
    public sealed class ExceptionBuilder : ExceptionBuilderBase<ExceptionBuilder, Exception>
    {
        protected override ExceptionBuilder Self => this;

        public override Exception Build()
        {
            return new Exception(Message, InnerException);
        }
    }
}
