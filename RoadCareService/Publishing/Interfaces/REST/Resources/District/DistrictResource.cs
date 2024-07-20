namespace RoadCareService.Publishing.Interfaces.REST.Resources.District
{
    public record DistrictResource(int Id,
        int DepartmentId, string Name);
}