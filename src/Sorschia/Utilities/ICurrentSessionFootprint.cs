using System;

namespace Sorschia.Utilities
{
    public interface ICurrentSessionFootprint
    {
        int? GetCurrentUserId();
        DateTimeOffset? GetCurrentTimestamp();
    }
}
