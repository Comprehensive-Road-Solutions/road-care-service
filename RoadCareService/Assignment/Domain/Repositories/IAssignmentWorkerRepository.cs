using RoadCareService.Assignment.Domain.Model.Aggregates;
using RoadCareService.Assignment.Domain.Model.ValueObjects.AssignmentWorker;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.Assignment.Domain.Repositories
{
    public interface IAssignmentWorkerRepository :
        IBaseRepository<AssignmentWorker>
    {
        Task<bool> UpdateAssignmentWorkerStateAsync
            (int id, EAssignmentWorkerState assignmentWorkerState);

        Task<IEnumerable<AssignmentWorker>> FindByGovernmentEntityIdAndWorkerAreaIdAsync
            (int governmentEntityId, int workerAreaId);

        Task<IEnumerable<AssignmentWorker>> FindByGovernmentEntityIdAndWorkerAreaIdAndRoleIdAsync
            (int governmentEntityId, int workerAreaId, int roleId);
    }
}