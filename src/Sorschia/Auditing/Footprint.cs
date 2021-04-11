using System;

namespace Sorschia.Auditing
{
    public struct Footprint
    {
        public int? UserId { get; }
        public DateTimeOffset? Timestamp { get; }

        public Footprint(int? userId, DateTimeOffset? timestamp) : this()
        {
            UserId = userId;
            Timestamp = timestamp;
        }
    }
}
