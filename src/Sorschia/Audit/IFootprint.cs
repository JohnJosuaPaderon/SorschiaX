using System;

namespace Sorschia.Audit
{
    public interface IFootprint
    {
        int? UserId { get; }
        DateTimeOffset? Timestamp { get; }
    }
}
