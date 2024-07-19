using RoadCareService.Assignment.Domain.Model.ValueObjects.WorkerArea;

namespace RoadCareService.Assignment.Domain.Model.Commands.WorkerArea
{
    public record CreateWorkerAreaCommand(int GovernmentsEntitiesId, string Name,
                                          EWorkerAreaState WorkerAreaState);
}