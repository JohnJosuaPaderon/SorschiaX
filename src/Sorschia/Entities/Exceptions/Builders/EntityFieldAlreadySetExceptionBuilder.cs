using System.Collections.Generic;

namespace Sorschia.Entities.Exceptions.Builders
{
    public sealed class EntityFieldAlreadySetExceptionBuilder : EntityExceptionBuilderBase<EntityFieldAlreadySetExceptionBuilder, EntityFieldAlreadySetException>
    {
        public IDictionary<string, object> Fields { get; } = new Dictionary<string, object>();

        public override EntityFieldAlreadySetException Build()
        {
            return new EntityFieldAlreadySetException(EntityType, Fields, Message, InnerException, IsUserFriendlyMessage);
        }

        protected override EntityFieldAlreadySetExceptionBuilder GetInstance() => this;

        public EntityFieldAlreadySetExceptionBuilder AddField(string key, object value)
        {
            Fields.Add(key, value);
            return GetInstance();
        }
    }
}
