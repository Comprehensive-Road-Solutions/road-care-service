using RoadCareService.Assignment.Domain.Model.ValueObjects.WorkerRole;

namespace RoadCareService.Assignment.Domain.Model.Commands.WorkerRole
{
    public record AddWorkerRoleToWorkerAreaCommand(int WorkersAreasId, string Name,
                                             EWorkerRoleState WorkerRoleState);
}