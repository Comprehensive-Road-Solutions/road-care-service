namespace RoadCareService.Assignment.Domain.Model.Queries.AssignmentWorker
{
    public record GetAssignmentsWorkersByGovernmentsEntitiesIdAndWorkersAreasIdAndRolesIdQuery
        (int GovernmentsEntitiesId, int WorkersAreasId, int RolesId);
}