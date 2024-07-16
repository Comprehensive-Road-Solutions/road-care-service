using RoadCareService.Publishing.Domain.Model.Commands.Publication;
using RoadCareService.Publishing.Domain.Model.ValueObjects;
using RoadCareService.Publishing.Interfaces.REST.Resources;

namespace RoadCareService.Publishing.Interfaces.REST.Transform
{
    public class CreatePublicationCommandFromResourceAssembler
    {
        public static CreatePublicationCommand ToCommandFromResource
            (CreatePublicationResource resource) =>
            new(resource.CitizensId, resource.DistrictsId,
                resource.Ubication, resource.Ubication,
                EPublicationState.PUBLICADO);
    }
}