namespace RoadCareService.Publishing.Interfaces.REST.Resources.Publication
{
    public record CreatePublicationResource(int CitizenId, int DistrictId,
                                            string Ubication, string Description);
}