namespace Sorschia.Entities
{
    public interface IRole
    {
        int Id { get; set; }
        string Name { get; set; }
        string? Description { get; set; }
        int? ApplicationId { get; set; }
    }
}
