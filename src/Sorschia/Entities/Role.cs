using System.Collections.Generic;

namespace Sorschia.Entities
{
    public class Role : RoleBase
    {
        public Application? Application { get; set; }
        public ICollection<Permission> Permissions { get; set; } = new List<Permission>();

        public const int NameMaxLength = 100;
        public const int DescriptionMaxLength = 500;
    }
}
