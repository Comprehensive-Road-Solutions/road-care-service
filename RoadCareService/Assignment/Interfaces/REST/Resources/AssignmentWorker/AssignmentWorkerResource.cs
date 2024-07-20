namespace RoadCareService.Assignment.Interfaces.REST.Resources.AssignmentWorker
{
    public record AssignmentWorkerResource
        (int Id, int WorkerRoleId, int WorkerId,
        DateOnly StartDate, DateOnly FinalDate,
        string AssignmentWorkerState);
}