using RoadCareService.Assignment.Domain.Model.Aggregates;
using RoadCareService.Assignment.Domain.Model.Queries.AssignmentWorker;
using RoadCareService.Assignment.Domain.Repositories;
using RoadCareService.Assignment.Domain.Services.AssignmentWorker;

namespace RoadCareService.Assignment.Application.Internal.QueryServices
{
    internal class AssignmentWorkerQueryService
        (IAssignmentWorkerRepository assignmentWorkerRepository) :
        IAssignmentWorkerQueryService
    {
        public async Task<IEnumerable<AssignmentWorker>> Handle
            (GetAllAssignmentsWorkersQuery query) =>
            await assignmentWorkerRepository.ListAsync();

        public async Task<AssignmentWorker?> Handle
            (GetAssignmentWorkerByIdQuery query) =>
            await assignmentWorkerRepository
            .FindByIdAsync(query.Id);

        public async Task<IEnumerable<AssignmentWorker>> Handle
            (GetAssignmentsWorkersByGovernmentEntityIdAndWorkerAreaIdAndRoleIdQuery query) =>
            await assignmentWorkerRepository
            .FindByGovernmentEntityIdAndWorkerAreaIdAndRoleIdAsync
            (query.GovernmentEntityId, query.WorkerAreaId, query.RoleId);

        public async Task<IEnumerable<AssignmentWorker>> Handle
            (GetAssignmentsWorkersByGovernmentEntityIdAndWorkerAreaIdQuery query) =>
            await assignmentWorkerRepository
            .FindByGovernmentEntityIdAndWorkerAreaIdAsync
            (query.GovernmentEntityId, query.WorkerAreaId);
    }
}