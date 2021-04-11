namespace Sorschia.Data.Exceptions.Builders
{
    public sealed class InvalidDbContextExceptionBuilder : InvalidDbContextExceptionBuilderBase<InvalidDbContextExceptionBuilder, InvalidDbContextException>
    {
        protected override InvalidDbContextExceptionBuilder Self => this;

        public override InvalidDbContextException Build()
        {
            return new InvalidDbContextException(Message, InnerException, UserFriendlyMessage, DbContextType);
        }
    }
}
