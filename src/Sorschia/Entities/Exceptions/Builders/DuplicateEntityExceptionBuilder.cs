namespace Sorschia.Entities.Exceptions.Builders
{
    public sealed class DuplicateEntityExceptionBuilder : DuplicateEntityExceptionBuilderBase<DuplicateEntityExceptionBuilder, DuplicateEntityException>
    {
        protected override DuplicateEntityExceptionBuilder Self => this;

        public override DuplicateEntityException Build()
        {
            return new DuplicateEntityException(Message, InnerException, UserFriendlyMessage, EntityType, Fields);
        }
    }
}
