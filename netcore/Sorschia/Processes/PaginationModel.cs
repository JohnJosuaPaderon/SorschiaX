namespace Sorschia.Processes
{
    public class PaginationModel<TId, TSkip, TTake> : QueryModel<TId>
        where TSkip : struct
        where TTake : struct
    {
        public TSkip? Skip { get; set; }
        public TTake? Take { get; set; }
    }
}
