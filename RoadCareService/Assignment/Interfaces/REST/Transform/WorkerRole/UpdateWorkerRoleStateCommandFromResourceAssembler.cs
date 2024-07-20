using RoadCareService.Assignment.Domain.Model.Commands.WorkerRole;
using RoadCareService.Assignment.Domain.Model.ValueObjects.WorkerRole;
using RoadCareService.Assignment.Interfaces.REST.Resources.WorkerRole;

namespace RoadCareService.Assignment.Interfaces.REST.Transform.WorkerRole
{
    public class UpdateWorkerRoleStateCommandFromResourceAssembler
    {
        public static UpdateWorkerRoleStateCommand ToCommandFromResource
            (UpdateWorkerRoleStateResource resource) =>
            new(resource.Id, Enum.Parse<EWorkerRoleState>
                (resource.WorkerRoleState));
    }
}