namespace RoadCareService.Publishing.Interfaces.REST.Resources
{
    public record CreatePublicationResource(int CitizensId, int DistrictsId,
                                            string Ubication, string Description);
}