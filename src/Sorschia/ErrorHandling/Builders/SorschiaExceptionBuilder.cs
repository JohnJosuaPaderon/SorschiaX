namespace Sorschia.ErrorHandling.Builders
{
    public sealed class SorschiaExceptionBuilder : SorschiaExceptionBuilderBase<SorschiaExceptionBuilder>, IExceptionBuilder<SorschiaException>
    {
        protected override SorschiaExceptionBuilder Self => this;

        public SorschiaException Build() => new(Message, InnerException, DebugMessage);
    }

    public abstract class SorschiaExceptionBuilderBase<TSelf> : ExceptionBuilderBase<TSelf>
    {
        public string DebugMessage { get; protected set; }

        public virtual TSelf WithDebugMessage(string message)
        {
            return Self;
        }
    }
}
