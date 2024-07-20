using RoadCareService.Assignment.Domain.Model.Entities;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.Assignment.Domain.Repositories
{
    public interface IWorkerRoleRepository : IBaseRepository<WorkerRole>
    {
        Task<IEnumerable<WorkerRole>?> FindByGovernmentsEntitiesIdAndWorkersIdAsync
            (int governmentsEntitiesId, int workersId);
    }
}