using RoadCareService.IAM.Domain.Model.ValueObjects.Credential;

namespace RoadCareService.IAM.Application.Internal.OutboundServices
{
    public interface ITokenService
    {
        string GenerateJwtToken(string id,
            string code, ECredentialRole credentialRole);

        object? ValidateToken(string? token);
    }
}