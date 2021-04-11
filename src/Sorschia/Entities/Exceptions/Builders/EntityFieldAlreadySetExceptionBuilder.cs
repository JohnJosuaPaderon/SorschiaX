namespace Sorschia.Entities.Exceptions.Builders
{
    public sealed class EntityFieldAlreadySetExceptionBuilder : EntityFieldAlreadySetExceptionBuilderBase<EntityFieldAlreadySetExceptionBuilder, EntityFieldAlreadySetException>
    {
        protected override EntityFieldAlreadySetExceptionBuilder Self => this;

        public override EntityFieldAlreadySetException Build()
        {
            return new EntityFieldAlreadySetException(Message, InnerException, UserFriendlyMessage, EntityType, FieldName, FieldValue);
        }
    }
}
