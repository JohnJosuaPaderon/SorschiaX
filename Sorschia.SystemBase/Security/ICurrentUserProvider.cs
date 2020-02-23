using Sorschia.SystemBase.Security.Entities;

namespace Sorschia.SystemBase.Security
{
    public interface ICurrentUserProvider
    {
        void Set(SystemUser user);
        SystemUser Get();
        int GetId();
        string GetUsername();
        string GetFullName();
        string GetInformalFullName();
    }
}
