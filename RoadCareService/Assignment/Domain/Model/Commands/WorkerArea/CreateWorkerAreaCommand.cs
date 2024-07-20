using RoadCareService.Assignment.Domain.Model.ValueObjects.WorkerArea;

namespace RoadCareService.Assignment.Domain.Model.Commands.WorkerArea
{
    public record CreateWorkerAreaCommand(int GovernmentEntityId, string Name,
                                          EWorkerAreaState WorkerAreaState);
}