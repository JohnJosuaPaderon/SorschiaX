using System.Collections.Generic;

namespace Sorschia.Exceptions.Builders
{
    public sealed class DuplicateEntityExceptionBuilder : EntityExceptionBuilderBase<DuplicateEntityExceptionBuilder>, IExceptionBuilder<DuplicateEntityException>
    {
        public List<EntityField> Fields { get; } = new();
        protected override DuplicateEntityExceptionBuilder Self => this;

        public DuplicateEntityException Build() => new(Message, InnerException, DebugMessage, EntityType, Fields);

        public DuplicateEntityExceptionBuilder AddField(EntityField field)
        {
            Fields.Add(field);
            return Self;
        }

        public DuplicateEntityExceptionBuilder AddField(string name, object? value) => AddField(new EntityField(name, value));

        public DuplicateEntityExceptionBuilder AddField(string name) => AddField(name, null);
    }
}
