using System.Collections.Generic;

namespace Sorschia.Entities
{
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public short? ApplicationId { get; set; }
        public int? RoleId { get; set; }

        public Application? Application { get; set; }
        public Role? Role { get; set; }
        public ICollection<PermissionAspNetRoute> AspNetRoutes { get; set; } = new HashSet<PermissionAspNetRoute>();

        public const int NameMaxLength = 100;
        public const int DescriptionMaxLength = 500;
    }
}
