using System;

namespace Sorschia.SystemCore
{
    public class RefreshToken
    {
        public Guid Id { get; set; }
        public Guid AccessTokenId { get; set; }
        public string TokenString { get; set; }
    }
}
