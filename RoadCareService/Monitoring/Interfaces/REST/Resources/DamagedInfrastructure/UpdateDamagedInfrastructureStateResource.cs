namespace RoadCareService.Monitoring.Interfaces.REST.Resources.DamagedInfrastructure
{
    public record UpdateDamagedInfrastructureStateResource(int Id,
        string DamagedInfrastructureState);
}