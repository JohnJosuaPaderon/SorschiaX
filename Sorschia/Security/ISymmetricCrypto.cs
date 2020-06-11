namespace Sorschia.Security
{
    public interface ISymmetricCrypto
    {
        byte[] Encrypt(byte[] plainBytes);
        byte[] Decrypt(byte[] cipherBytes);
    }

    public interface ISymmetricCryptoFactory
    {
        ISymmetricCrypto this[string identifier] { get; }
    }

    public sealed class SymmetricCryptoRegistration
    {
        
    }
}
