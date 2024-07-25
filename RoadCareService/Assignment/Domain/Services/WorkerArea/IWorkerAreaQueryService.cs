using RoadCareService.Assignment.Domain.Model.Queries.WorkerArea;

namespace RoadCareService.Assignment.Domain.Services.WorkerArea
{
    public interface IWorkerAreaQueryService
    {
        Task<IEnumerable<Model.Entities.WorkerArea>> Handle
            (GetAllWorkersAreasQuery query);
        Task<Model.Entities.WorkerArea?> Handle
            (GetWorkerAreaByIdQuery query);
        Task<IEnumerable<Model.Entities.WorkerArea>> Handle
            (GetWorkersAreasByGovernmentEntityIdAndStateQuery query);
        Task<IEnumerable<Model.Entities.WorkerArea>> Handle
            (GetWorkersAreasByGovernmentEntityIdQuery query);
    }
}