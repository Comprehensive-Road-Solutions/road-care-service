using RoadCareService.IAM.Application.Internal.OutboundServices;
using RoadCareService.IAM.Domain.Model.Queries.WorkerCredential;
using RoadCareService.IAM.Domain.Model.ValueObjects.Credential;
using RoadCareService.IAM.Domain.Repositories;
using RoadCareService.IAM.Domain.Services.WorkerCredential;

namespace RoadCareService.IAM.Application.Internal.QueryServices
{
    public class WorkerCredentialQueryService
        (IWorkerCredentialRepository workerCredentialRepository,
        IEncryptionService encryptionService,
        ITokenService tokenService) :
        IWorkerCredentialQueryService
    {
        public async Task<string?> Handle
            (GetWorkerCredentialByWorkerIdAndCodeQuery query)
        {
            var result = await workerCredentialRepository
                .FindByWorkerIdAsync(query.Id);

            if (string.IsNullOrEmpty(result))
                return null;

            if (!encryptionService.VerifyHash
                (query.Code, result[..24],
                result[24..]))
                return null;

            return tokenService.GenerateJwtToken
                (query.Id.ToString(), query.Code,
                ECredentialRole.TRABAJADOR);
        }
    }
}