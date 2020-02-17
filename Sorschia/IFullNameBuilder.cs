namespace Sorschia
{
    public interface IFullNameBuilder
    {
        string Build(NameBase name);
        string Build(string firstName, string middleName, string lastName, string nameExtension);
    }
}
