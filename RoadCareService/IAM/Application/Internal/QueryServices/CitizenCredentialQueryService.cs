using RoadCareService.IAM.Application.Internal.OutboundServices;
using RoadCareService.IAM.Domain.Model.Queries.CitizenCredential;
using RoadCareService.IAM.Domain.Model.ValueObjects.Credential;
using RoadCareService.IAM.Domain.Repositories;
using RoadCareService.IAM.Domain.Services.CitizenCredential;

namespace RoadCareService.IAM.Application.Internal.QueryServices
{
    internal class CitizenCredentialQueryService
        (ICitizenCredentialRepository citizenCredentialRepository,
        IEncryptionService encryptionService,
        ITokenService tokenService) :
        ICitizenCredentialQueryService
    {
        public async Task<dynamic?> Handle
            (GetCitizenCredentialByCitizenIdAndCodeQuery query)
        {
            var result = await citizenCredentialRepository
                .FindByCitizenIdAsync(query.Id);

            if (string.IsNullOrEmpty(result))
                return null;

            if (!encryptionService.VerifyHash
                (query.Code, result[..24],
                result[24..]))
                return null;

            return new
            {
                Token = tokenService.GenerateJwtToken
                (new
                {
                    Id = query.Id.ToString(),
                    query.Code,
                    Role = ECredentialRole
                    .CIUDADANO.ToString()
                }),
                Result = true
            };
        }
    }
}