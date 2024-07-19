using RoadCareService.Assignment.Domain.Model.ValueObjects.Role;

namespace RoadCareService.Assignment.Domain.Model.Commands.WorkerRole
{
    public record AddRoleToWorkerAreaCommand(int WorkersAreasId, string Name,
                                             ERoleState RoleState);
}