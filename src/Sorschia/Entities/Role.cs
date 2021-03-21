using System.Collections.Generic;

namespace Sorschia.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public short? ApplicationId { get; set; }

        public Application? Application { get; set; }
        public ICollection<Permission> Permissions { get; set; } = new HashSet<Permission>();

        public const int NameMaxLength = 100;
        public const int DescriptionMaxLength = 500;
    }
}
