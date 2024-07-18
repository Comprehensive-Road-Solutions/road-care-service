namespace RoadCareService.Monitoring.Domain.Model.Queries
{
    public record GetDamagedInfrastructureByDepartmentsIdAndDistrictsIdQuery
        (int DepartmentsId, int DistrictsId);
}