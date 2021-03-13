namespace Sorschia.Utilities
{
    public interface IName
    {
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        string NameSuffix { get; set; }
        string FullName { get; set; }
    }
}
