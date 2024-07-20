namespace RoadCareService.Monitoring.Interfaces.REST.Resources.Staff
{
    public record StaffResource(int Id, int DamagedInfrastructureId,
                                int WorkerId, string StaffState);
}