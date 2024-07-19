namespace RoadCareService.Monitoring.Interfaces.REST.Resources.DamagedInfrastructure
{
    public record RegisterDamagedInfrastructureResource(int DistrictsId,
                                                        string Description,
                                                        string Address);
}