using RoadCareService.IAM.Domain.Model.Aggregates;
using RoadCareService.IAM.Domain.Model.Queries.Worker;
using RoadCareService.IAM.Domain.Repositories;
using RoadCareService.IAM.Domain.Services.Worker;

namespace RoadCareService.IAM.Application.Internal.QueryServices
{
    internal class WorkerQueryService
        (IWorkerRepository workerRepository) :
        IWorkerQueryService
    {
        public async Task<Worker?> Handle
            (GetWorkerByIdQuery query) =>
            await workerRepository
            .FindByIdAsync(query.Id);
    }
}