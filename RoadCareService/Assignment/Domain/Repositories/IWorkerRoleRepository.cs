using RoadCareService.Assignment.Domain.Model.Entities;
using RoadCareService.Assignment.Domain.Model.ValueObjects.WorkerRole;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.Assignment.Domain.Repositories
{
    public interface IWorkerRoleRepository :
        IBaseRepository<WorkerRole>
    {
        Task<bool> UpdateWorkerRoleStateAsync
            (int id, EWorkerRoleState workerRoleState);
        Task<IEnumerable<WorkerRole>> FindByGovernmentEntityIdAndWorkerAreaIdAsync
            (int governmentEntityId, int workerAreaId);
    }
}