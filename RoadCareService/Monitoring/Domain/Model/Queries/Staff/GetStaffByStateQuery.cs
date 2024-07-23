using RoadCareService.Monitoring.Domain.Model.ValueObjects.Staff;

namespace RoadCareService.Monitoring.Domain.Model.Queries.Staff
{
    public record GetStaffByStateQuery
        (EStaffState StaffState);
}