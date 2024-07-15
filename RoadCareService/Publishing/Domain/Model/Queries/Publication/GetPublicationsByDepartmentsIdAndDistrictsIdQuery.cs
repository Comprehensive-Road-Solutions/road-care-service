namespace RoadCareService.Publishing.Domain.Model.Queries.Publication
{
    public record GetPublicationsByDepartmentsIdAndDistrictsIdQuery(int DepartmentsId,
                                                                    int DistrictsId);
}