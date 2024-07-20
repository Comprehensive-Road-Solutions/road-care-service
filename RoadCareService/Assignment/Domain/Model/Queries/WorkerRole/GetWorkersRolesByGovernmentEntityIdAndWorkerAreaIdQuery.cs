namespace RoadCareService.Assignment.Domain.Model.Queries.WorkerRole
{
    public record GetWorkersRolesByGovernmentEntityIdAndWorkerAreaIdQuery
        (int GovernmentEntityId, int WorkerAreaId);
}