namespace Sorschia.Entities
{
    public interface IApplication
    {
        short Id { get; set; }
        string Name { get; set; }
        string? Description { get; set; }
    }
}
