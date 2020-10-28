using Microsoft.IdentityModel.Tokens;
using Sorschia.SystemCore.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Sorschia.SystemCore
{
    internal sealed class AccessTokenGenerator : IAccessTokenGenerator
    {
        private readonly AccessTokenConfiguration _configuration;

        public AccessTokenGenerator(AccessTokenConfiguration configuration)
        {
            _configuration = configuration;
        }

        private JwtSecurityToken GenerateToken(IEnumerable<Claim> claims)
        {
            var credentials = new SigningCredentials(_configuration.GetIssuerSigningKey(), SecurityAlgorithms.HmacSha256);
            return new JwtSecurityToken(_configuration.Issuer, _configuration.Audience, claims: claims, expires: DateTime.Now.AddMinutes(_configuration.AccessExpiration), signingCredentials: credentials);
        }

        public AccessToken Generate(Session session)
        {
            var claims = new List<Claim>
            {
                new Claim(SorschiaClaims.SystemCore.SessionId, session.Id.ToString()),
                new Claim(SorschiaClaims.SystemCore.UserId, session.UserId.ToString()),
                new Claim(SorschiaClaims.SystemCore.ApplicationId, session.ApplicationId.ToString())
            };

            var token = GenerateToken(claims);

            return new AccessToken
            {
                SessionId = session.Id,
                TokenString = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            };
        }
    }
}
