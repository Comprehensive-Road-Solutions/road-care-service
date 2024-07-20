using RoadCareService.Monitoring.Domain.Model.ValueObjects.Staff;

namespace RoadCareService.Monitoring.Domain.Model.Commands.Staff
{
    public record AddStaffInChargeCommand(int DamagedInfrastructureId,
        int WorkerId, EStaffState StaffState);
}