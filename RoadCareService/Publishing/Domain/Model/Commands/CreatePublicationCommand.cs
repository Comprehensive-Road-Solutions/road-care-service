namespace RoadCareService.Publishing.Domain.Model.Commands
{
    public record CreatePublicationCommand(int CitizensId, int DistrictsId,
                                           string Ubication, string Description,
                                           string State);
}