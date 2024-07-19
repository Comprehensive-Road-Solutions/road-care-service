using RoadCareService.Assignment.Domain.Model.ValueObjects.WorkerArea;

namespace RoadCareService.Assignment.Domain.Model.Commands.WorkerArea
{
    public record UpdateWorkerAreaStateCommand(int Id, EWorkerAreaState WorkerAreaState);
}