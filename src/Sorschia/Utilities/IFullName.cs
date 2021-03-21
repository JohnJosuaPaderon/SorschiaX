namespace Sorschia.Utilities
{
    public interface IFullName
    {
        string FirstName { get; set; }
        string? MiddleName { get; set; }
        string LastName { get; set; }
        string? NameSuffix { get; set; }
        string FullName { get; set; }
    }
}
