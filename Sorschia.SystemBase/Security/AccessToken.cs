using System;

namespace Sorschia.SystemBase.Security
{
    public class AccessToken
    {
        public Guid Id { get; set; }
        public Guid SessionId { get; set; }
        public string TokenString { get; set; }
        public DateTime Expiration { get; set; }
    }
}
