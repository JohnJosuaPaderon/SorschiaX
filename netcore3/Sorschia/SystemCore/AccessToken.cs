using System;

namespace Sorschia.SystemCore
{
    public class AccessToken
    {
        public long Id { get; set; }
        public long SessionId { get; set; }
        public string TokenString { get; set; }
        public DateTime Expiration { get; set; }
    }
}
