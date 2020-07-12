using Sorschia.SystemCore.Entities;

namespace Sorschia.SystemCore
{
    public interface IAccessTokenGenerator
    {
        AccessToken Generate(Session session);
    }
}
