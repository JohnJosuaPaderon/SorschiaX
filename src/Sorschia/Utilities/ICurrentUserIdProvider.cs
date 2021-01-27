namespace Sorschia.Utilities
{
    public interface ICurrentUserIdProvider
    {
        int? CurrentUserId { get; set; }
    }
}
