using RoadCareService.Assignment.Domain.Model.ValueObjects.WorkerRole;

namespace RoadCareService.Assignment.Domain.Model.Commands.WorkerRole
{
    public record UpdateWorkerRoleStateCommand(int Id, EWorkerRoleState WorkerRoleState);
}