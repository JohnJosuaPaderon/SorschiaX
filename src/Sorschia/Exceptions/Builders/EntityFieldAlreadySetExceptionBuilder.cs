namespace Sorschia.Exceptions.Builders
{
    public sealed class EntityFieldAlreadySetExceptionBuilder : EntityExceptionBuilderBase<EntityFieldAlreadySetExceptionBuilder>, IExceptionBuilder<EntityFieldAlreadySetException>
    {
        public EntityField? Field { get; private set; }
        protected override EntityFieldAlreadySetExceptionBuilder Self => this;

        public EntityFieldAlreadySetException Build() => new(Message, InnerException, DebugMessage, EntityType, Field);

        public EntityFieldAlreadySetExceptionBuilder WithField(EntityField field)
        {
            Field = field;
            return Self;
        }

        public EntityFieldAlreadySetExceptionBuilder WithField(string name, object? value) => WithField(new EntityField(name, value));

        public EntityFieldAlreadySetExceptionBuilder WithField(string name) => WithField(name, null);
    }
}
