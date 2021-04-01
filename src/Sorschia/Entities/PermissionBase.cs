namespace Sorschia.Entities
{
    public abstract class PermissionBase
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public short? ApplicationId { get; set; }
        public int? RoleId { get; set; }
    }
}
