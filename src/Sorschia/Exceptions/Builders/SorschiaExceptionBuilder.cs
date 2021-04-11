namespace Sorschia.Exceptions.Builders
{
    public sealed class SorschiaExceptionBuilder : SorschiaExceptionBuilderBase<SorschiaExceptionBuilder, SorschiaException>
    {
        protected override SorschiaExceptionBuilder Self => this;

        public override SorschiaException Build()
        {
            return new SorschiaException(Message, InnerException, UserFriendlyMessage);
        }
    }
}
