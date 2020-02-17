namespace Sorschia
{
    public interface IInformalFullNameBuilder
    {
        string Build(NameBase name);
        string Build(string firstName, string middleInitials, string lastName, string nameExtension);
    }
}
