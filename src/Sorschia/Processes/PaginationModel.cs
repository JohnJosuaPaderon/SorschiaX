namespace Sorschia.Processes
{
    public class PaginationModel<TCount>
    {
        public TCount SkippedCount { get; set; }
        public TCount TakenCount { get; set; }
    }

    public class PaginationModel : PaginationModel<int>
    {
    }
}
