namespace RoadCareService.Monitoring.Domain.Model.Queries.DamagedInfrastructure
{
    public record GetDamagedInfrastructureByDepartmentsIdAndDistrictsIdQuery
        (int DepartmentsId, int DistrictsId);
}