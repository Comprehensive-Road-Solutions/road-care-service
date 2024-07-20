namespace RoadCareService.Monitoring.Domain.Model.Queries.DamagedInfrastructure
{
    public record GetDamagedInfrastructuresByDepartmentsIdAndDistrictsIdQuery
        (int DepartmentId, int DistrictId);
}