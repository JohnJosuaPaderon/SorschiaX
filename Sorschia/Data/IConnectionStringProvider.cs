namespace Sorschia.Data
{
    public interface IConnectionStringProvider
    {
        string this[string key] { get; }
    }
}
