namespace RoadCareService.Monitoring.Domain.Model.Queries.DamagedInfrastructure
{
    public record GetDamagedInfrastructuresByDepartmentsIdAndDistrictsIdQuery
        (int DepartmentsId, int DistrictsId);
}