namespace Sorschia.Entities
{
    public class PermissionAspNetRoute : PermissionAspNetRouteBase
    {
        public Permission? Permission { get; set; }

        public const int AspNetAreaMaxLength = 100;
        public const int AspNetControllerMaxLength = 100;
        public const int AspNetActionMaxLength = 100;
    }
}
