namespace Sorschia.Entities
{
    public interface IFullNameBuilder
    {
        string Build(string firstName, string middleName, string lastName, string nameSuffix);
        string Build(IFullNameHolder holder);
    }
}
