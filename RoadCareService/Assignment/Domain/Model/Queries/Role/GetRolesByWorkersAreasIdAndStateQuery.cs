using RoadCareService.Assignment.Domain.Model.ValueObjects.Role;

namespace RoadCareService.Assignment.Domain.Model.Queries.Role
{
    public record GetRolesByWorkersAreasIdAndStateQuery
        (int WorkersAreasId, ERoleState RoleState);
}