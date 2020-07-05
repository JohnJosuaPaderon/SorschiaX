namespace Sorschia.Security
{
    public interface IRsaPrivateKeyStore
    {
        RsaKeys Initialize(string purpose);
        string Request(string purpose);
    }
}
