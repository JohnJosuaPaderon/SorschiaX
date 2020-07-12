namespace Sorschia.SystemCore
{
    public interface IRefreshTokenGenerator
    {
        RefreshToken Generate(AccessToken accessToken);
    }
}
