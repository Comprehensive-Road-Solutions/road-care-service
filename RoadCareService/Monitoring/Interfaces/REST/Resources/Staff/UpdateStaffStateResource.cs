namespace RoadCareService.Monitoring.Interfaces.REST.Resources.Staff
{
    public record UpdateStaffStateResource(int Id, int WorkersId,
                                           string StaffState);
}