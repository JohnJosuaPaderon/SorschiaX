namespace Sorschia.Entities
{
    public interface INameable
    {
        string FirstName { get; set; }
        string? MiddleName { get; set; }
        string LastName { get; set; }
        string? NameExtension { get; set; }
        string FullName { get; set; }
    }
}
