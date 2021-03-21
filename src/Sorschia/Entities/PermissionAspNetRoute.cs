namespace Sorschia.Entities
{
    public class PermissionAspNetRoute
    {
        public long Id { get; set; }
        public int PermissionId { get; set; }
        public string? AspNetArea { get; set; }
        public string AspNetController { get; set; } = default!;
        public string AspNetAction { get; set; } = default!;

        public Permission Permission { get; set; } = default!;

        public const int AspNetAreaMaxLength = 100;
        public const int AspNetControllerMaxLength = 100;
        public const int AspNetActionMaxLength = 100;
    }
}
