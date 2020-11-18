namespace Sorschia.Processes
{
    public class PaginationResult<TTotalCount>
        where TTotalCount : struct
    {
        public TTotalCount TotalCount { get; set; }
    }
}
