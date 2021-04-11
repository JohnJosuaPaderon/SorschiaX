namespace Sorschia.Entities.Exceptions.Builders
{
    public sealed class EntityExceptionBuilder : EntityExceptionBuilderBase<EntityExceptionBuilder, EntityException>
    {
        protected override EntityExceptionBuilder Self => this;

        public override EntityException Build()
        {
            return new EntityException(Message, InnerException, UserFriendlyMessage, EntityType);
        }
    }
}
