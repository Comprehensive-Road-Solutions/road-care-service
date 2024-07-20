namespace RoadCareService.Assignment.Domain.Model.Queries.AssignmentWorker
{
    public record GetAssignmentsWorkersByGovernmentEntityIdAndWorkerAreaIdQuery
        (int GovernmentEntityId, int WorkerAreaId);
}