using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace iRental.BusinessLogicLayer.Options
{
    public class JwtAuthOption
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public TimeSpan AccessTokenExpiration { get; set; } = TimeSpan.FromMinutes(1);
        public TimeSpan RefreshTokenExpiration { get; set; } = TimeSpan.FromMinutes(2);
        public string Key { get; set; }

        public TokenValidationParameters GetTokenValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = Issuer,
                ValidAudience = Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key))
            };
        }

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
        }
    }
}
