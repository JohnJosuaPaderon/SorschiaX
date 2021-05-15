namespace Sorschia.Exceptions.Builders
{
    /// <summary>
    /// An implementation of <see cref="IExceptionBuilder{TException}"/> to build an instance of <see cref="SorschiaException"/>
    /// </summary>
    public sealed class SorschiaExceptionBuilder : SorschiaExceptionBuilderBase<SorschiaExceptionBuilder>, IExceptionBuilder<SorschiaException>
    {
        protected override SorschiaExceptionBuilder Self => this;

        public SorschiaException Build() => new(Message, InnerException, DebugMessage);
    }
}
