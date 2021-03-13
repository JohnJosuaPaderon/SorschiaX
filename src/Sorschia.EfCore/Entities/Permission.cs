using System.Collections.Generic;

namespace Sorschia.Entities
{
    public class Permission : EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LookupKey { get; set; }
        public short? ApplicationId { get; set; }
        public int? RoleId { get; set; }

        public Application Application { get; set; }
        public Role Role { get; set; }
        public ICollection<PermissionAspNetRoute> AspNetRoutes { get; set; } = new List<PermissionAspNetRoute>();
    }
}
