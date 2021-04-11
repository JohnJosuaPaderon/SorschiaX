namespace Sorschia.Entities.Exceptions.Builders
{
    public sealed class DuplicateEntityFieldExceptionBuilder : DuplicateEntityFieldExceptionBuilderBase<DuplicateEntityFieldExceptionBuilder, DuplicateEntityFieldException>
    {
        protected override DuplicateEntityFieldExceptionBuilder Self => this;

        public override DuplicateEntityFieldException Build()
        {
            return new DuplicateEntityFieldException(Message, InnerException, UserFriendlyMessage, EntityType, FieldName, FieldValue);
        }
    }
}
