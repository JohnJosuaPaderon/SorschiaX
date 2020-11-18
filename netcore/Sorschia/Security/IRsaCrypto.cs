namespace Sorschia.Security
{
    public interface IRsaCrypto
    {
        byte[] Encrypt(byte[] data, string publicKeyString);
        string Encrypt(string text, string publicKeyString);
        byte[] Decrypt(byte[] cipherData, string privateKeyString);
        string Decrypt(string cipherText, string privateKeyString);
    }
}
