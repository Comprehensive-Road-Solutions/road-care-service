using RoadCareService.IAM.Domain.Model.Queries.WorkerCredential;
using RoadCareService.IAM.Domain.Repositories;
using RoadCareService.IAM.Domain.Services.Worker;

namespace RoadCareService.IAM.Application.Internal.QueryServices
{
    public class WorkerQueryService
        (IWorkerRepository workerRepository) :
        IWorkerQueryService
    {
        public async Task<bool> Handle
            (GetWorkerCredentialByIdAndCodeQuery query) =>
            await workerRepository
            .FinByIdAndCodeAsync
            (query.Id, query.Code);
    }
}