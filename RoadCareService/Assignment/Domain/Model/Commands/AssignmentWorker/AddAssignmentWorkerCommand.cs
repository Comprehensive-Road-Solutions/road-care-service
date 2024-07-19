using RoadCareService.Assignment.Domain.Model.ValueObjects.AssignmentWorker;

namespace RoadCareService.Assignment.Domain.Model.Commands.AssignmentWorker
{
    public record AddAssignmentWorkerCommand(int RolesId, int WorkersId,
                                             DateOnly StartDate, DateOnly FinalDate,
                                             EAssignmentWorkerState AssignmentWorkerState);
}