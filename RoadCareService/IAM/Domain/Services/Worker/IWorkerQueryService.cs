using RoadCareService.IAM.Domain.Model.Queries.Worker;

namespace RoadCareService.IAM.Domain.Services.Worker
{
    public interface IWorkerQueryService
    {
        Task<Model.Aggregates.Worker?> Handle
            (GetWorkerByIdQuery query);
    }
}