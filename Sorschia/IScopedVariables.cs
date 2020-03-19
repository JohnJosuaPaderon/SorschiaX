namespace Sorschia
{
    public interface IScopedVariables
    {
        object this[string key] { get; set; }
        bool Exists(string key);
        bool Remove(string key);
        void Clear();
    }
}
