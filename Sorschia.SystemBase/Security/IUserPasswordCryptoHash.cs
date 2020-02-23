namespace Sorschia.SystemBase.Security
{
    public interface IUserPasswordCryptoHash
    {
        string Compute(string userPassword);
    }
}
