namespace Sorschia.SystemCore
{
    internal interface IUserPasswordPrivateKeyProvider
    {
        void Register(string keyString);
        string Request();
    }
}
