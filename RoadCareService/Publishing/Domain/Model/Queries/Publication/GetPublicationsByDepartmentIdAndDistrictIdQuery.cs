namespace RoadCareService.Publishing.Domain.Model.Queries.Publication
{
    public record GetPublicationsByDepartmentIdAndDistrictIdQuery
        (int DepartmentId, int DistrictId);
}