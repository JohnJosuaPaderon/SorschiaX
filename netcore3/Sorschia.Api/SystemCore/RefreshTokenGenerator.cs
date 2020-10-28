using System;
using System.Security.Cryptography;

namespace Sorschia.SystemCore
{
    internal sealed class RefreshTokenGenerator : IRefreshTokenGenerator
    {
        public RefreshToken Generate(AccessToken accessToken)
        {
            var randomNumberBytes = new byte[32];
            using var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(randomNumberBytes);
            return new RefreshToken
            {
                TokenString = Convert.ToBase64String(randomNumberBytes),
                AccessTokenId = accessToken.Id
            };
        }
    }
}
