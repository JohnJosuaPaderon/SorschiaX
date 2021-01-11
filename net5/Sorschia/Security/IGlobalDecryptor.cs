namespace Sorschia.Security
{
    public interface IGlobalDecryptor
    {
        string? Decrypt(string? cipherText);
    }
}
