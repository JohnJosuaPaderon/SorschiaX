namespace Sorschia.Process
{
    public abstract class PaginatedResult
    {
        public int? Skip { get; set; }
        public int? Take { get; set; }
        public int TotalCount { get; set; }
    }
}
