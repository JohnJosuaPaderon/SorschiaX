namespace Sorschia.SystemCore
{
    public interface IUserPasswordCryptoTransformer
    {
        string ComputeHash(string cipherPassword);
    }
}
