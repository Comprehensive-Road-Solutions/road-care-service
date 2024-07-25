using RoadCareService.Assignment.Domain.Model.Entities;
using RoadCareService.Assignment.Domain.Model.ValueObjects.WorkerArea;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.Assignment.Domain.Repositories
{
    public interface IWorkerAreaRepository :
        IBaseRepository<WorkerArea>
    {
        Task<bool> UpdateWorkerAreaStateAsync
            (int id, EWorkerAreaState workerAreaState);
        Task<IEnumerable<WorkerArea>> FindByGovernmentEntityIdAndStateAsync
            (int governmentEntityId, EWorkerAreaState workerAreaState);
        Task<IEnumerable<WorkerArea>> FindByGovernmentEntityIdAsync
            (int governmentEntityId);
    }
}