using System;

namespace Sorschia.Utilities
{
    public struct Footprint
    {
        public int? UserId { get; }
        public DateTimeOffset? Timestamp { get; }

        public Footprint(int? userId, DateTimeOffset? timestamp)
        {
            UserId = userId;
            Timestamp = timestamp;
        }
    }
}
