using System;
using System.Security.Cryptography;

namespace Sorschia.SystemCore
{
    internal sealed class RefreshTokenGenerator : IRefreshTokenGenerator
    {
        public RefreshToken Generate(AccessToken accessToken)
        {
            if (accessToken is null)
                throw SorschiaException.InvalidParameter<AccessToken>(nameof(accessToken));

            if (Equals(accessToken.Id, Guid.Empty))
                throw new SorschiaException("Access token id is invalid");

            if (string.IsNullOrWhiteSpace(accessToken.TokenString))
                throw new SorschiaException("Access token is invalid");

            var resultBytes = new byte[32];
            using var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(resultBytes);

            return new RefreshToken
            {
                AccessTokenId = accessToken.Id,
                TokenString = Convert.ToBase64String(resultBytes)
            };
        }
    }
}
