using RoadCareService.Interaction.Domain.Model.Commands;
using RoadCareService.Interaction.Domain.Model.ValueObjects;
using RoadCareService.Interaction.Interfaces.REST.Resources;

namespace RoadCareService.Interaction.Interfaces.REST.Transform
{
    public class AddCommentToPublicationCommandFromResourceAssembler
    {
        public static AddCommentToPublicationCommand ToCommandFromResource
            (AddCommentToPublicationResource resource) =>
            new(resource.PublicationId, resource.CitizenId,
                resource.Opinion, ECommentState.ENVIADO);
    }
}