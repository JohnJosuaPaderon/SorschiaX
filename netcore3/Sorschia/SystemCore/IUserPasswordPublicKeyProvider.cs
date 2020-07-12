namespace Sorschia.SystemCore
{
    public interface IUserPasswordPublicKeyProvider
    {
        void Register(string keyString);
        string Request();
    }
}
