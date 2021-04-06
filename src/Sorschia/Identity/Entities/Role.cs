using System.Collections.Generic;

namespace Sorschia.Identity.Entities
{
    public class Role : RoleBase
    {
        public IEnumerable<Permission> Permissions { get; set; }

        public const int LookupCodeMaxLength = 20;
        public const int NameMaxLength = 100;
        public const int DescriptionMaxLength = 500;
    }
}
