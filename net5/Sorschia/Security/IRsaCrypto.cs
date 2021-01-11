namespace Sorschia.Security
{
    public interface IRsaCrypto
    {
        byte[]? Encrypt(byte[]? data, string publicKeyString);
        byte[]? Decrypt(byte[]? cipherData, string privateKeyString);
    }
}
