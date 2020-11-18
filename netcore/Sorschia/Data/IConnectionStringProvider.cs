namespace Sorschia.Data
{
    public interface IConnectionStringProvider
    {
        string this[string key, params string[] fallbackKeys] { get; set; }
    }
}
