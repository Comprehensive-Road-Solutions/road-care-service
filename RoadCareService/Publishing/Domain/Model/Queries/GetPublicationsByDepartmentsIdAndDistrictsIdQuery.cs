namespace RoadCareService.Publishing.Domain.Model.Queries
{
    public record GetPublicationsByDepartmentsIdAndDistrictsIdQuery(int DepartmentsId,
                                                                    int DistrictsId);
}