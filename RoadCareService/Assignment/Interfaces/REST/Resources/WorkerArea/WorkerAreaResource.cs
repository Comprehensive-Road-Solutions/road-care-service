namespace RoadCareService.Assignment.Interfaces.REST.Resources.WorkerArea
{
    public record WorkerAreaResource
        (int Id,int GovernmentEntityId,
        string Name, string WorkerAreaState);
}