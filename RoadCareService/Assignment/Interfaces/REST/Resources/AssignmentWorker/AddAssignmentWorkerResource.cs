namespace RoadCareService.Assignment.Interfaces.REST.Resources.AssignmentWorker
{
    public record AddAssignmentWorkerResource(int RoleId, int WorkerId,
        DateOnly StartDate, DateOnly FinalDate, string AssignmentWorkerState);
}