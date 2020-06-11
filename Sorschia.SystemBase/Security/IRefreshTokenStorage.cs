namespace Sorschia.SystemBase.Security
{
    public interface IRefreshTokenStorage
    {
        void Set(RefreshToken token);
        RefreshToken Get();
    }
}
