using System.Collections.Generic;

namespace Sorschia.Processes
{
    public class PaginationInput<TCount> where TCount : struct
    {
        public IList<TCount> SkippedIds { get; set; }
        public TCount? SkippedCount { get; set; }
        public TCount? TakenCount { get; set; }
    }

    public class PaginationInputInt32 : PaginationInput<int>
    {
    }

    public class PaginationInputInt64 : PaginationInput<long>
    {
    }
}
