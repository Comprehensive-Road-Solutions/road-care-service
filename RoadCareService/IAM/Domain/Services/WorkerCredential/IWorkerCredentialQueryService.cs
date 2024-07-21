using RoadCareService.IAM.Domain.Model.Queries.WorkerCredential;

namespace RoadCareService.IAM.Domain.Services.WorkerCredential
{
    public interface IWorkerCredentialQueryService
    {
        Task<string?> Handle
            (GetWorkerCredentialByIdAndCodeQuery query);
    }
}