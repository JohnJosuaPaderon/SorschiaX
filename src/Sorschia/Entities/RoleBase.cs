namespace Sorschia.Entities
{
    public abstract class RoleBase
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public short? ApplicationId { get; set; }
    }
}
