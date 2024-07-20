using RoadCareService.Assignment.Domain.Model.Entities;
using RoadCareService.Assignment.Domain.Model.ValueObjects.WorkerRole;
using RoadCareService.Assignment.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.Assignment.Infrastructure.Persistence.EFC.Repositories
{
    public class WorkerRoleRepository(RoadCareContext context) :
        BaseRepository<WorkerRole>(context), IWorkerRoleRepository
    {
        public Task<bool> UpdateWorkerRoleStateAsync(int id, EWorkerRoleState workerRoleState)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<WorkerRole>?> FindByGovernmentsEntitiesIdAndWorkersIdAsync
            (int governmentsEntitiesId, int workersId)
        {
            throw new NotImplementedException();
        }
    }
}