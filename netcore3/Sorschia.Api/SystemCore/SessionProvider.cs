using Sorschia.SystemCore.Entities;

namespace Sorschia.SystemCore
{
    internal sealed class SessionProvider : ISessionProvider
    {
        public Session Current { get; set; }
    }
}
