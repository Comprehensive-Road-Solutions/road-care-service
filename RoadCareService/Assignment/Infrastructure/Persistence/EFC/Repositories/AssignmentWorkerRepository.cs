using RoadCareService.Assignment.Domain.Model.Aggregates;
using RoadCareService.Assignment.Domain.Model.ValueObjects.AssignmentWorker;
using RoadCareService.Assignment.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.Assignment.Infrastructure.Persistence.EFC.Repositories
{
    public class AssignmentWorkerRepository(RoadCareContext context) :
        BaseRepository<AssignmentWorker>(context), IAssignmentWorkerRepository
    {
        public Task<bool> UpdateAssignmentWorkerStateAsync(int id, EAssignmentWorkerState assignmentWorkerState)
        {
            throw new NotImplementedException();
        }
        public Task<bool> UpdateAssignmentWorkerStateAsync
            (EAssignmentWorkerState assignmentWorkerState)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<AssignmentWorker>?> FindByGovernmentsEntitiesIdAndWorkersAreasIdAndRolesIdAsync
            (int governmentsEntitiesId, int workersAreasId, int rolesId)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<AssignmentWorker>?> FindByGovernmentsEntitiesIdAndWorkersAreasIdAsync
            (int governmentsEntitiesId, int workersAreasId)
        {
            throw new NotImplementedException();
        }
    }
}