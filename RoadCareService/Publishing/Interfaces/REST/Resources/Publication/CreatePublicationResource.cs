namespace RoadCareService.Publishing.Interfaces.REST.Resources.Publication
{
    public record CreatePublicationResource(int CitizensId, int DistrictsId,
                                            string Ubication, string Description);
}