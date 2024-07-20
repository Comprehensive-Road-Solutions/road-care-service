using RoadCareService.Publishing.Domain.Model.ValueObjects;

namespace RoadCareService.Publishing.Domain.Model.Commands.Publication
{
    public record CreatePublicationCommand(int CitizenId, int DistrictId,
        string Ubication, string Description, EPublicationState PublicationState);
}