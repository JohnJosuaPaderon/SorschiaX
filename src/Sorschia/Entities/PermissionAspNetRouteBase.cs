namespace Sorschia.Entities
{
    public abstract class PermissionAspNetRouteBase
    {
        public long Id { get; set; }
        public int PermissionId { get; set; }
        public string? AspNetArea { get; set; }
        public string AspNetController { get; set; } = default!;
        public string AspNetAction { get; set; } = default!;
    }
}
