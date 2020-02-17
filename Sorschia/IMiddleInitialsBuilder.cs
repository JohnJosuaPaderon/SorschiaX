namespace Sorschia
{
    public interface IMiddleInitialsBuilder
    {
        string Build(NameBase name);
        string Build(string middleName);
    }
}
