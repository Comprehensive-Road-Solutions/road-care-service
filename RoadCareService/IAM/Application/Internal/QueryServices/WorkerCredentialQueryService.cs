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
        public async Task<(string?, bool)> Handle
            (GetWorkerCredentialByWorkerIdAndCodeQuery query)
        {
            var result = await workerCredentialRepository
                .FindByWorkerIdAsync(query.Id);

            if (result is null)
                return (null, false);

            if (string.IsNullOrEmpty
                (result.WorkerCredentialCode))
                return (null, false);

            string code = result.WorkerCredentialCode;

            if (!encryptionService.VerifyHash
                (query.Code, code[..24], code[24..]))
                return (null, false);

            return (tokenService.GenerateJwtToken
                (new
                {
                    Id = query.Id.ToString(),
                    query.Code,
                    Role = ECredentialRole
                    .TRABAJADOR.ToString(),
                    result.DistrictName,
                    result.WorkerAreaName
                }), true);
        }
    }
}