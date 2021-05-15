using System.Collections.Generic;

namespace Sorschia.Exceptions.Builders
{
    public sealed class EntityNotFoundExceptionBuilder : EntityExceptionBuilderBase<EntityNotFoundExceptionBuilder>, IExceptionBuilder<EntityNotFoundException>
    {
        public List<EntityField> Fields { get; } = new();
        protected override EntityNotFoundExceptionBuilder Self => this;

        public EntityNotFoundException Build() => new(Message, InnerException, DebugMessage, EntityType, Fields);

        public EntityNotFoundExceptionBuilder AddField(EntityField field)
        {
            Fields.Add(field);
            return Self;
        }

        public EntityNotFoundExceptionBuilder AddField(string name, object? value) => AddField(new EntityField(name, value));

        public EntityNotFoundExceptionBuilder AddField(string name) => AddField(name, null);
    }
}
