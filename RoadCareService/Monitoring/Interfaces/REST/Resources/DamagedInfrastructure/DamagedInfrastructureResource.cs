namespace RoadCareService.Monitoring.Interfaces.REST.Resources.DamagedInfrastructure
{
    public record DamagedInfrastructureResource(int Id, int DistrictsId,
                                                DateTime RegistrationDate,
                                                string Description,string Address,
                                                DateTime? WorkDate,
                                                string DamagedInfrastructureState);
}