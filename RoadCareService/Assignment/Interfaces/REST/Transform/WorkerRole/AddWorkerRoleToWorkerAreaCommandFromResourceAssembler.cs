using RoadCareService.Assignment.Domain.Model.Commands.WorkerRole;
using RoadCareService.Assignment.Domain.Model.ValueObjects.WorkerRole;
using RoadCareService.Assignment.Interfaces.REST.Resources.WorkerRole;

namespace RoadCareService.Assignment.Interfaces.REST.Transform.WorkerRole
{
    public class AddWorkerRoleToWorkerAreaCommandFromResourceAssembler
    {
        public static AddWorkerRoleToWorkerAreaCommand ToCommandFromResource
            (AddWorkerRoleToWorkerAreaResource resource) =>
            new(resource.WorkerAreaId, resource.Name,
                EWorkerRoleState.ACTIVO);
    }
}