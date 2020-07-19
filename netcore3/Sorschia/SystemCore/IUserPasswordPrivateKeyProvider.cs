namespace Sorschia.SystemCore
{
    public interface IUserPasswordPrivateKeyProvider
    {
        void Register(string keyString);
        string Request();
    }
}
