namespace RoadCareService.IAM.Application.Internal.OutboundServices
{
    public interface ITokenService
    {
        string GenerateJwtToken(string id,
            string code, string role);

        object? ValidateToken(string? token);
    }
}