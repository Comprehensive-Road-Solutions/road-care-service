namespace RoadCareService.Assignment.Interfaces.REST.Resources.WorkerRole
{
    public record AddWorkerRoleToWorkerAreaResource
        (int WorkerAreaId, string Name,
        string WorkerRoleState);
}