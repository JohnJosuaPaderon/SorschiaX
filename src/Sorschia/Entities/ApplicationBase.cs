namespace Sorschia.Entities
{
    public abstract class ApplicationBase
    {
        public short Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }
}
