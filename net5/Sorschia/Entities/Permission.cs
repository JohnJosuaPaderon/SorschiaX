using System.Collections.Generic;

namespace Sorschia.Entities
{
    public class Permission : EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }

        public ICollection<UserPermission> Users { get; set; } = new List<UserPermission>();
    }
}
