using RoadCareService.Monitoring.Domain.Model.ValueObjects.Staff;

namespace RoadCareService.Monitoring.Domain.Model.Commands.Staff
{
    public record UpdateStaffStateCommand(int Id, EStaffState StaffState);
}