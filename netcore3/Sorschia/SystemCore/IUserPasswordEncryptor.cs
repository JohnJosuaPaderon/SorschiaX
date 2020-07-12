namespace Sorschia.SystemCore
{
    public interface IUserPasswordEncryptor
    {
        string Encrypt(string password);
    }
}
