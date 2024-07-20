namespace RoadCareService.Assignment.Interfaces.REST.Resources.WorkerRole
{
    public record WorkerRoleResource
        (int Id, int WorkerAreaId,
        string Name, string WorkerRoleState);
}