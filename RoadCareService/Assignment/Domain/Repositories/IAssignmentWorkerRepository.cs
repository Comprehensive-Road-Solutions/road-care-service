using RoadCareService.Assignment.Domain.Model.Aggregates;
using RoadCareService.Assignment.Domain.Model.ValueObjects.AssignmentWorker;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.Assignment.Domain.Repositories
{
    public interface IAssignmentWorkerRepository :
        IBaseRepository<AssignmentWorker>
    {
        Task<bool> UpdateAssignmentWorkerStateAsync
            (EAssignmentWorkerState assignmentWorkerState);
        Task<IEnumerable<AssignmentWorker>?> FindByGovernmentsEntitiesIdAndWorkersAreasIdAndRolesIdAsync
            (int governmentsEntitiesId, int workersAreasId, int rolesId);
        Task<IEnumerable<AssignmentWorker>?> FindByGovernmentsEntitiesIdAndWorkersAreasIdAsync
            (int governmentsEntitiesId, int workersAreasId);
    }
}