using Microsoft.AspNetCore.Http;
using System;

namespace Sorschia.SystemCore
{
    internal sealed class SessionIdProvider : ISessionIdProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public SessionIdProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public long? GetCurrent()
        {
            if (_httpContextAccessor.HttpContext.User.TryGetClaimValueInt64(SorschiaClaims.SystemCore.SessionId, out long sessionId))
                return sessionId;

            return default;
        }

        public void SetCurrent(long currentUserId)
        {
            throw new NotImplementedException("Managed by the claimsprincipal");
        }
    }
}
