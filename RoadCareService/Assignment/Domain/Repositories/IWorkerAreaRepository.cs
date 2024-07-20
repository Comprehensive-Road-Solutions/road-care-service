using RoadCareService.Assignment.Domain.Model.Entities;
using RoadCareService.Assignment.Domain.Model.ValueObjects.WorkerArea;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.Assignment.Domain.Repositories
{
    public interface IWorkerAreaRepository : IBaseRepository<WorkerArea>
    {
        Task<IEnumerable<WorkerArea>?> FindByWorkersAreasByGovernmentsEntitiesIdAndStateAsync
            (int governmentsEntitiesId, EWorkerAreaState workerAreaState);
        Task<IEnumerable<WorkerArea>?> FindByWorkersAreasByGovernmentsEntitiesIdAsync
            (int governmentsEntitiesId);
    }
}