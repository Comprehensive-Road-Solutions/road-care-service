using RoadCareService.IAM.Domain.Model.Queries.Worker;
using RoadCareService.IAM.Domain.Repositories;
using RoadCareService.IAM.Domain.Services.Worker;

namespace RoadCareService.IAM.Application.Internal.QueryServices
{
    internal class WorkerQueryService
        (IWorkerRepository workerRepository) :
        IWorkerQueryService
    {
        public async Task<bool> Handle
            (GetWorkerByIdQuery query)
        {
            var result = await workerRepository
                .FindByIdAsync(query.Id);

            if (result is null)
                return false;

            return true;
        }
    }
}