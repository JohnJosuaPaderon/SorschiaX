using Sorschia.SystemBase.Security.Entities;
using System;

namespace Sorschia.SystemBase.Security
{
    public interface ICurrentSessionProvider
    {
        void Set(SystemSession session);
        SystemSession Get();
        Guid? GetId();
    }
}
