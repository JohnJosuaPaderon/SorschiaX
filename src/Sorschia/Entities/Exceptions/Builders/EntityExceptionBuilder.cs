namespace Sorschia.Entities.Exceptions.Builders
{
    public sealed class EntityExceptionBuilder : EntityExceptionBuilderBase<EntityExceptionBuilder, EntityException>
    {
        public override EntityException Build()
        {
            return new EntityException(EntityType, Message, InnerException, IsUserFriendlyMessage);
        }

        protected override EntityExceptionBuilder GetInstance() => this;
    }
}
