namespace Sorschia.Security
{
    public interface IUserPasswordCryptoHash
    {
        string Compute(string password);
    }
}
