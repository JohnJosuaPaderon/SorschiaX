using Sorschia.SystemBase.Security.Entities;

namespace Sorschia.SystemBase.Security
{
    public interface IAccessTokenCreator
    {
        AccessToken Create(SystemSession session);
    }
}
