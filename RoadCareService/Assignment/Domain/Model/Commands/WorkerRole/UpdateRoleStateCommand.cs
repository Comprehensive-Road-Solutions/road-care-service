using RoadCareService.Assignment.Domain.Model.ValueObjects.Role;

namespace RoadCareService.Assignment.Domain.Model.Commands.WorkerRole
{
    public record UpdateRoleStateCommand(int Id, ERoleState RoleState);
}