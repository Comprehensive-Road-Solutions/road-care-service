namespace RoadCareService.Publishing.Interfaces.REST.Resources
{
    public record PublicationResource(int Id, int CitizensId, int DistrictsId,
                                      string Ubication, string Description);
}