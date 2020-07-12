namespace Sorschia.SystemCore
{
    public interface IUserPasswordDecryptor
    {
        string Decrypt(string cipherPassword);
    }
}
