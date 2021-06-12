namespace Sorschia.Identity.Utilities
{
    public interface IUserPasswordTransformer
    {
        string ToSecurePassword(string password);
    }
}
