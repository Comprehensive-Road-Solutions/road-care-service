using RoadCareService.Assignment.Domain.Model.Aggregates;
using RoadCareService.Assignment.Domain.Model.Queries.AssignmentWorker;
using RoadCareService.Assignment.Domain.Repositories;
using RoadCareService.Assignment.Domain.Services.AssignmentWorker;

namespace RoadCareService.Assignment.Application.Internal.QueryServices
{
    public class AssignmentWorkerQueryService
        (IAssignmentWorkerRepository assignmentWorkerRepository) :
        IAssignmentWorkerQueryService
    {
        public Task<IEnumerable<AssignmentWorker>?> Handle
            (GetAllAssignmentsWorkersQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<AssignmentWorker?> Handle
            (GetAssignmentWorkerByIdQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AssignmentWorker>?> Handle
            (GetAssignmentsWorkersByGovernmentEntityIdAndWorkerAreaIdAndRoleIdQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AssignmentWorker>?> Handle
            (GetAssignmentsWorkersByGovernmentEntityIdAndWorkerAreaIdQuery query)
        {
            throw new NotImplementedException();
        }
    }
}