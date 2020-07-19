using System;

namespace Sorschia.SystemCore
{
    public class RefreshToken
    {
        public long Id { get; set; }
        public long AccessTokenId { get; set; }
        public string TokenString { get; set; }
    }
}
