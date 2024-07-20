namespace RoadCareService.Assignment.Domain.Model.Queries.WorkerRole
{
    public record GetWorkersRolesByGovernmentsEntitiesIdAndWorkersAreasIdQuery
        (int GovernmentsEntitiesId, int WorkersAreasId);
}