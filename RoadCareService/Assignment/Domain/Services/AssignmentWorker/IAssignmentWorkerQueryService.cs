using RoadCareService.Assignment.Domain.Model.Queries.AssignmentWorker;

namespace RoadCareService.Assignment.Domain.Services.AssignmentWorker
{
    public interface IAssignmentWorkerQueryService
    {
        Task<IEnumerable<Model.Aggregates.AssignmentWorker>?> Handle
            (GetAllAssignmentsWorkersQuery query);
        Task<Model.Aggregates.AssignmentWorker?> Handle
            (GetAssignmentWorkerByIdQuery query);
        Task<IEnumerable<Model.Aggregates.AssignmentWorker>?> Handle
            (GetAssignmentsWorkersByGovernmentsEntitiesIdAndWorkersAreasIdAndRolesIdQuery query);
        Task<IEnumerable<Model.Aggregates.AssignmentWorker>?> Handle
            (GetAssignmentsWorkersByGovernmentsEntitiesIdAndWorkersAreasIdQuery query);
    }
}