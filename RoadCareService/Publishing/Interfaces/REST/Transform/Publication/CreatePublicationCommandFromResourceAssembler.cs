using RoadCareService.Publishing.Domain.Model.Commands.Publication;
using RoadCareService.Publishing.Domain.Model.ValueObjects.Publication;
using RoadCareService.Publishing.Interfaces.REST.Resources.Publication;

namespace RoadCareService.Publishing.Interfaces.REST.Transform.Publication
{
    public class CreatePublicationCommandFromResourceAssembler
    {
        public static CreatePublicationCommand ToCommandFromResource
            (CreatePublicationResource resource) =>
            new(resource.CitizenId, resource.DistrictId,
                resource.Ubication, resource.Ubication,
                EPublicationState.PUBLICADO);
    }
}