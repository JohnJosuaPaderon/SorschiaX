using System.Collections.Generic;

namespace Sorschia.Entities
{
    public class Application : EntityBase
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Role> Roles { get; set; } = new List<Role>();
        public ICollection<Permission> Permissions { get; set; } = new List<Permission>();
    }
}
