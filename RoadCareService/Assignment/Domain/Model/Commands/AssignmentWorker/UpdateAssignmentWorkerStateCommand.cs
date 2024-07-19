using RoadCareService.Assignment.Domain.Model.ValueObjects.AssignmentWorker;

namespace RoadCareService.Assignment.Domain.Model.Commands.AssignmentWorker
{
    public record UpdateAssignmentWorkerStateCommand(int Id,
        EAssignmentWorkerState AssignmentWorkerState);
}