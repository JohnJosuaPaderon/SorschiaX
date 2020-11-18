namespace Sorschia.Security
{
    public interface IKeyStringProvider
    {
        void Register(string keyString);
        string Request();
    }
}
