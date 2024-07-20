using RoadCareService.Assignment.Domain.Model.Commands.WorkerArea;
using RoadCareService.Assignment.Domain.Model.ValueObjects.WorkerArea;
using RoadCareService.Assignment.Interfaces.REST.Resources.WorkerArea;

namespace RoadCareService.Assignment.Interfaces.REST.Transform.WorkerArea
{
    public class UpdateWorkerAreaStateCommandFromResourceAssembler
    {
        public static UpdateWorkerAreaStateCommand ToCommandFromResource
            (UpdateWorkerAreaStateResource resource) =>
            new(resource.Id, Enum.Parse<EWorkerAreaState>
                (resource.WorkerAreaState));
    }
}