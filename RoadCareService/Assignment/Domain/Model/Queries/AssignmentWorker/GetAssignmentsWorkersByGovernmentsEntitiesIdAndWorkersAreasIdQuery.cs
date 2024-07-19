namespace RoadCareService.Assignment.Domain.Model.Queries.AssignmentWorker
{
    public record GetAssignmentsWorkersByGovernmentsEntitiesIdAndWorkersAreasIdQuery
        (int GovernmentsEntitiesId, int WorkersAreasId);
}