namespace RoadCareService.Monitoring.Interfaces.REST.Resources.Staff
{
    public record AddStaffInChargeResource(int DamagedInfrastructureId,
                                           int WorkerId);
}