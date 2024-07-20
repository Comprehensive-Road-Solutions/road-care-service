namespace RoadCareService.Assignment.Domain.Model.Queries.AssignmentWorker
{
    public record GetAssignmentsWorkersByGovernmentEntityIdAndWorkerAreaIdAndRoleIdQuery
        (int GovernmentEntityId, int WorkerAreaId, int RoleId);
}