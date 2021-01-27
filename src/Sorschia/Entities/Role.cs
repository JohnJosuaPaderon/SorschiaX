using System.Collections.Generic;

namespace Sorschia.Entities
{
    public class Role : EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ApplicationId { get; set; }

        public Application Application { get; set; }
        public ICollection<Permission> Permissions { get; set; } = new List<Permission>();
    }
}
