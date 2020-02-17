namespace Sorschia.Security
{
    public interface ICryptor
    {
        string Encrypt(string plainText, string cryptoKey);
        string Encrypt(string plainText, string cryptoKey, byte[] salt, byte[] iv);
        string Encrypt(string plainText, string cryptoKey, out byte[] salt, out byte[] iv);
        string Decrypt(string cipherText, string cryptoKey);
        string Decrypt(string cipherText, string cryptoKey, byte[] salt, byte[] iv);
    }
}
