namespace Sorschia.Identity.Entities
{
    public class Permission : PermissionBase
    {
        public Role Role { get; set; }

        public const int LookupCodeMaxLength = 20;
        public const int NameMaxLength = 100;
        public const int DescriptionMaxLength = 500;
    }
}
