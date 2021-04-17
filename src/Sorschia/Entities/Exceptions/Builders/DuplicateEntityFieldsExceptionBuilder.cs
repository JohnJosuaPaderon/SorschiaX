namespace Sorschia.Entities.Exceptions.Builders
{
    public sealed class DuplicateEntityFieldsExceptionBuilder : DuplicateEntityFieldsExceptionBuilderBase<DuplicateEntityFieldsExceptionBuilder, DuplicateEntityFieldsException>
    {
        protected override DuplicateEntityFieldsExceptionBuilder Self => this;

        public override DuplicateEntityFieldsException Build()
        {
            return new DuplicateEntityFieldsException(Message, InnerException, UserFriendlyMessage, EntityType, Fields);
        }
    }
}
