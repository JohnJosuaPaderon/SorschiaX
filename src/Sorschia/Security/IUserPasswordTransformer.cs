namespace Sorschia.Security
{
    public interface IUserPasswordTransformer
    {
        string ToSecurePassword(string password);
    }
}
