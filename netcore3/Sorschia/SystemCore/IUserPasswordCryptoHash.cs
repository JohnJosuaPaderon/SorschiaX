namespace Sorschia.SystemCore
{
    public interface IUserPasswordCryptoHash
    {
        string ComputeHash(string password);
    }
}
