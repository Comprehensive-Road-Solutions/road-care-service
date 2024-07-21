using RoadCareService.IAM.Domain.Model.Queries.Worker;
using RoadCareService.IAM.Domain.Repositories;
using RoadCareService.IAM.Domain.Services.Worker;

namespace RoadCareService.IAM.Application.Internal.QueryServices
{
    public class WorkerQueryService
        (IWorkerRepository workerRepository) :
        IWorkerQueryService
    {
        public async Task<bool> Handle
            (GetWorkerByIdAndCodeQuery query) =>
            await workerRepository
            .FinByIdAndCodeAsync
            (query.Id, query.Code);
    }
}