using System.Collections.Generic;

namespace Sorschia.Entities
{
    public class Permission : PermissionBase
    {
        public Application? Application { get; set; }
        public Role? Role { get; set; }
        public ICollection<PermissionAspNetRoute> AspNetRoutes { get; set; } = new List<PermissionAspNetRoute>();

        public const int NameMaxLength = 100;
        public const int DescriptionMaxLength = 500;
    }
}
