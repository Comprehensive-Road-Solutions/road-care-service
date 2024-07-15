using RoadCareService.Publishing.Domain.Model.ValueObjects;

namespace RoadCareService.Publishing.Domain.Model.Commands
{
    public record CreatePublicationCommand(int CitizensId, int DistrictsId,
                                           string Ubication, string Description,
                                           EPublicationState PublicationState);
}