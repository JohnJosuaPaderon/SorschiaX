namespace Sorschia.Entities.Exceptions.Builders
{
    public sealed class EntityNotFoundExceptionBuilder : EntityNotFoundExceptionBuilderBase<EntityNotFoundExceptionBuilder, EntityNotFoundException>
    {
        protected override EntityNotFoundExceptionBuilder Self => this;

        public override EntityNotFoundException Build()
        {
            return new EntityNotFoundException(Message, InnerException, UserFriendlyMessage, EntityType, Fields);
        }
    }
}
