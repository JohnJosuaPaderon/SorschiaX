using System;

namespace Sorschia.Utilities
{
    public struct ResourceConsumerIdentifier
    {
        internal Guid InternalId { get; set; }

        internal void NewInternalId()
        {
            InternalId = Guid.NewGuid();
        }

        public static implicit operator Guid(ResourceConsumerIdentifier source)
        {
            return source.InternalId;
        }
    }
}
