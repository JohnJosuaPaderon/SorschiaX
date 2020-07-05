namespace Sorschia.Security
{
    public interface IRsaPublicKeyStore
    {
        void Register(string purpose, string publicKey);
        string Request(string purpose);
    }
}
