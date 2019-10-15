﻿using iRental.BusinessLogicLayer.Options;
using iRental.Domain.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace iRental.BusinessLogicLayer.Helpers
{
    public class JwtManager
    {
        private readonly JwtAuthOption _jwtAuthOptions;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

        public JwtManager(IOptions<JwtAuthOption> jwtAuthOptions)
        {
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            _jwtAuthOptions = jwtAuthOptions.Value;
        }

        private string GenerateJwt(ClaimsIdentity identity, TimeSpan expireTokenMinutes)
        {
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                _jwtAuthOptions.Issuer,
                _jwtAuthOptions.Audience,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(expireTokenMinutes),
                signingCredentials: new SigningCredentials(_jwtAuthOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256));
            var encodedJwt = _jwtSecurityTokenHandler.WriteToken(jwt);
            return encodedJwt;
        }

        public string GenerateAccessToken(UserIdentity user, IEnumerable<string> userRoles)
        {
            var accessClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, $"{user.NormalizedFirstName} ${user.NormalizedLastName}")
            };

            foreach (var userRole in userRoles) accessClaims.Add(new Claim(ClaimTypes.Role, userRole));

            var accessClaimsIdentity = new ClaimsIdentity(accessClaims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return GenerateJwt(accessClaimsIdentity, _jwtAuthOptions.AccessTokenExpiration);
        }

        public string GenerateRefreshToken(UserIdentity user)
        {
            var refreshClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
            };

            var accessClaimsIdentity = new ClaimsIdentity(refreshClaims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return GenerateJwt(accessClaimsIdentity, _jwtAuthOptions.RefreshTokenExpiration);
        }
    }
}
