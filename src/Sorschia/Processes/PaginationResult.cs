using System.Collections.Generic;

namespace Sorschia.Processes
{
    public class PaginationResult<TEntity, TCount>
    {
        public IEnumerable<TEntity> Data { get; set; }
        public TCount TotalCount { get; set; }
    }

    public class PaginationResult<TEntity> : PaginationResult<TEntity, int>
    {
    }
}
