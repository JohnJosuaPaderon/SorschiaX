using System.Collections.Generic;

namespace Sorschia.Entities.Exceptions.Builders
{
    public sealed class EntityNotFoundExceptionBuilder : EntityExceptionBuilderBase<EntityNotFoundExceptionBuilder, EntityNotFoundException>
    {
        public IDictionary<string, object> Fields { get; } = new Dictionary<string, object>();

        public override EntityNotFoundException Build()
        {
            return new EntityNotFoundException(EntityType, Fields, Message, InnerException, IsUserFriendlyMessage);
        }

        protected override EntityNotFoundExceptionBuilder GetInstance() => this;

        public EntityNotFoundExceptionBuilder AddField(string key, object value)
        {
            Fields.Add(key, value);
            return GetInstance();
        }
    }
}
