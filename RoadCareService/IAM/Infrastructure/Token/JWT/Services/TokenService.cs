using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using RoadCareService.IAM.Application.Internal.OutboundServices;
using RoadCareService.IAM.Domain.Model.ValueObjects.Credential;
using RoadCareService.IAM.Infrastructure.Token.JWT.Configuration;

namespace RoadCareService.IAM.Infrastructure.Token.JWT.Services
{
    internal class TokenService
        (IOptions<JwtSettings> tokenSettings) :
        ITokenService
    {
        private JwtSettings TokenConfiguration = tokenSettings.Value;

        public string GenerateJwtToken(dynamic credential)
        {
            SymmetricSecurityKey securityKey = new
                (Encoding.ASCII.GetBytes
                (TokenConfiguration.JWT_SECRET_KEY));

            SigningCredentials credentials = new
                (securityKey, SecurityAlgorithms.HmacSha256);

            Claim[]? claims = [];

            if (credential.Role ==
                ECredentialRole.TRABAJADOR.ToString())
            {
                claims =
                [
                    new Claim(ClaimTypes.Sid, credential.Id),
                    new Claim(ClaimTypes.Hash, credential.Code),
                    new Claim(ClaimTypes.Role, credential.Role),
                    new Claim(ClaimTypes.StateOrProvince, credential.DistrictId),
                    new Claim(ClaimTypes.AuthorizationDecision, credential.WorkerAreaName)
                ];
            }
            else if (credential.Role ==
                ECredentialRole.CIUDADANO.ToString())
            {
                claims =
                [
                    new Claim(ClaimTypes.Sid, credential.Id),
                    new Claim(ClaimTypes.Hash, credential.Code),
                    new Claim(ClaimTypes.Role, credential.Role)
                ];
            }

            JwtSecurityToken token = new(
                issuer: TokenConfiguration.JWT_ISSUER_TOKEN,
                audience: TokenConfiguration.JWT_AUDIENCE_TOKEN,
                claims: claims,
                expires: DateTime.UtcNow
                .AddMinutes(TokenConfiguration.JWT_EXPIRE_MINUTES),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public dynamic? ValidateToken(string? token)
        {
            if (string.IsNullOrEmpty(token))
                return null;

            try
            {
                var securityKey = new SymmetricSecurityKey
                    (Encoding.Default.GetBytes
                    (TokenConfiguration.JWT_SECRET_KEY));

                JwtSecurityTokenHandler tokenHandler = new();

                TokenValidationParameters validationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = TokenConfiguration.JWT_ISSUER_TOKEN,
                    ValidAudience = TokenConfiguration.JWT_AUDIENCE_TOKEN,
                    IssuerSigningKey = securityKey,
                    LifetimeValidator = LifetimeValidator,
                    ClockSkew = TimeSpan.Zero
                };

                var principal = tokenHandler.ValidateToken(token,
                    validationParameters, out SecurityToken securityToken);

                if (securityToken is JwtSecurityToken jwtToken)
                    if (!jwtToken.Header.Alg.Equals(SecurityAlgorithms
                        .HmacSha256, StringComparison
                        .InvariantCultureIgnoreCase))
                        return null;

                var result = (JwtSecurityToken)securityToken;

                var id = Convert.ToInt32(result.Claims.First
                    (claim => claim.Type == ClaimTypes.Sid).Value);

                var code = Convert.ToString(result.Claims.First
                    (claim => claim.Type == ClaimTypes.Hash).Value);

                var role = Convert.ToString(result.Claims.First
                    (claim => claim.Type == ClaimTypes.Role).Value);

                if (role.ToUpper() == ECredentialRole
                    .TRABAJADOR.ToString())
                    return new { Id = id, Code = code, Role = role,
                        DistrictId = Convert.ToString
                        (result.Claims.First(claim =>
                        claim.Type == ClaimTypes.StateOrProvince).Value),
                        WorkerAreaName = Convert.ToString
                        (result.Claims.First(claim =>
                        claim.Type == ClaimTypes.AuthorizationDecision).Value)
                    };

                if (role.ToUpper() == ECredentialRole
                    .CIUDADANO.ToString())
                    return new { Id = id, Code = code, Role = role };
            }
            catch (Exception) { return null; }

            throw new NotImplementedException();
        }

        private bool LifetimeValidator(DateTime? notBefore,
            DateTime? expires, SecurityToken securityToken,
            TokenValidationParameters validationParameters)
        {
            if (expires != null)
                if (DateTime.UtcNow < expires) return true;

            return false;
        }
    }
}