namespace Sorschia.SystemBase.Security
{
    public interface IAccessTokenStorage
    {
        void Set(AccessToken token);
        AccessToken Get();
    }
}
