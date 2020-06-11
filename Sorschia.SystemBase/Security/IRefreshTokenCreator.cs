namespace Sorschia.SystemBase.Security
{
    public interface IRefreshTokenCreator
    {
        RefreshToken Create(AccessToken accessToken);
    }
}
