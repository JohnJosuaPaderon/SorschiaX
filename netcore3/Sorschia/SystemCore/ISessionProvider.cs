using Sorschia.SystemCore.Entities;

namespace Sorschia.SystemCore
{
    public interface ISessionProvider
    {
        Session Current { get; set; }
    }
}
