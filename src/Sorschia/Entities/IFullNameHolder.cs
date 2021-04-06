namespace Sorschia.Entities
{
    public interface IFullNameHolder
    {
        string FirstName { get; }
        string MiddleName { get; }
        string LastName { get; }
        string NameSuffix { get; }
        string FullName { get; }
    }
}
