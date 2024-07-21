using RoadCareService.IAM.Domain.Model.Queries.WorkerCredential;

namespace RoadCareService.IAM.Domain.Services.Worker
{
    public interface IWorkerQueryService
    {
        Task<bool> Handle
            (GetWorkerCredentialByIdAndCodeQuery query);
    }
}