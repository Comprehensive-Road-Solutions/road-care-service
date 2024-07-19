using RoadCareService.Assignment.Domain.Model.ValueObjects.Role;

namespace RoadCareService.Assignment.Domain.Model.Commands.Role
{
    public record UpdateRoleStateCommand(int Id, ERoleState RoleState);
}