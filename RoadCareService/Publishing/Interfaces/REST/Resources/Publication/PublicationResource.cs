namespace RoadCareService.Publishing.Interfaces.REST.Resources.Publication
{
    public record PublicationResource(int Id, int CitizenId, int DistrictId,
                                      string Ubication, string Description);
}