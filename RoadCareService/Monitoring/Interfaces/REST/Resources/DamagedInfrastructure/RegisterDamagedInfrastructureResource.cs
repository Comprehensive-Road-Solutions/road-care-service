namespace RoadCareService.Monitoring.Interfaces.REST.Resources.DamagedInfrastructure
{
    public record RegisterDamagedInfrastructureResource(int DistrictId,
                                                        string Description,
                                                        string Address);
}