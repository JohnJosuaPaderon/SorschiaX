using System;

namespace Sorschia.SystemBase.Security
{
    public class RefreshToken
    {
        public Guid Id { get; set; }
        public Guid AccessTokenId { get; set; }
        public string TokenString { get; set; }
    }
}
