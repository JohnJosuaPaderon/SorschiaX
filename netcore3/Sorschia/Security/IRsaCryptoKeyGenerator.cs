namespace Sorschia.Security
{
    public interface IRsaCryptoKeyGenerator
    {
        RsaCryptoKeyPair Generate();
    }
}
