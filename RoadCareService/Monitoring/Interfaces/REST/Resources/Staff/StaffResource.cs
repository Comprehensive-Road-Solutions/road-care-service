namespace RoadCareService.Monitoring.Interfaces.REST.Resources.Staff
{
    public record StaffResource(int Id, int DamagedInfrastructuresId,
                                int WorkersId, string StaffState);
}