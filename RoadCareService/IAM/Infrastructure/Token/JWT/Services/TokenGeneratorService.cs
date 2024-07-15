using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using RoadCareService.IAM.Infrastructure.Token.JWT.Configuration;

namespace RoadCareService.IAM.Infrastructure.Token.JWT.Services
{
    internal class TokenGeneratorService(IOptions<JwtSettings> tokenSettings)
    {
        private JwtSettings TokenConfiguration = tokenSettings.Value;

        public string GenerateJwtToken(string id, string name)
        {
            SymmetricSecurityKey securityKey = new(Encoding.ASCII.GetBytes(TokenConfiguration.JWT_SECRET_KEY));
            SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sid, id),
                new Claim(JwtRegisteredClaimNames.Name, name)
            };

            JwtSecurityToken token = new(
                issuer: TokenConfiguration.JWT_ISSUER_TOKEN,
                audience: TokenConfiguration.JWT_AUDIENCE_TOKEN,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(TokenConfiguration.JWT_EXPIRE_MINUTES),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}