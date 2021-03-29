namespace Sorschia.Exceptions.Builders
{
    public sealed class SorschiaExceptionBuilder : SorschiaExceptionBuilderBase<SorschiaExceptionBuilder, SorschiaException>
    {
        public override SorschiaException Build()
        {
            return new SorschiaException(Message, InnerException, IsUserFriendlyMessage);
        }

        protected override SorschiaExceptionBuilder GetInstance() => this;
    }
}
