namespace RoadCareService.Assignment.Interfaces.REST.Resources.AssignmentWorker
{
    public record AssignmentWorkerResource
        (int Id, int RoleId, int WorkerId,
        DateOnly StartDate, DateOnly FinalDate,
        string AssignmentWorkerState);
}