namespace Sorschia.Identity.Entities
{
    public abstract class PermissionBase
    {
        public int Id { get; set; }
        public int? RoleId { get; set; }
        public string LookupCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
