namespace RoadCareService.Monitoring.Interfaces.REST.Resources.DamagedInfrastructure
{
    public record DamagedInfrastructureResource(int Id, int DistrictId, DateTime RegistrationDate,
        string Description, string Address, DateTime? WorkDate, string DamagedInfrastructureState);
}