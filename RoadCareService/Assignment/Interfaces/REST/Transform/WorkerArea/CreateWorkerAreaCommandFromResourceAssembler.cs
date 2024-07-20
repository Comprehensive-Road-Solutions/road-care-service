using RoadCareService.Assignment.Domain.Model.Commands.WorkerArea;
using RoadCareService.Assignment.Domain.Model.ValueObjects.WorkerArea;
using RoadCareService.Assignment.Interfaces.REST.Resources.WorkerArea;

namespace RoadCareService.Assignment.Interfaces.REST.Transform.WorkerArea
{
    public class CreateWorkerAreaCommandFromResourceAssembler
    {
        public static CreateWorkerAreaCommand ToCommandFromResource
            (CreateWorkerAreaResource resource) =>
            new(resource.GovernmentEntityId, resource.Name,
                EWorkerAreaState.ACTIVO);
    }
}