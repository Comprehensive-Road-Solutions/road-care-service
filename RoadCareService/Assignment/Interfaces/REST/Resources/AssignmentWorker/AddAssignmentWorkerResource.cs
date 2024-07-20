namespace RoadCareService.Assignment.Interfaces.REST.Resources.AssignmentWorker
{
    public record AddAssignmentWorkerResource
        (int WorkerRoleId, int WorkerId,
        DateOnly StartDate, DateOnly FinalDate,
        string AssignmentWorkerState);
}