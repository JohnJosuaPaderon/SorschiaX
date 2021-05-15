namespace Sorschia.Utilities
{
    public interface IFullNameHolder
    {
        string FirstName { get; }
        string? MiddleName { get; }
        string LastName { get; }
        string? NmeSuffix { get; }
        string FullName { get; }
    }
}
