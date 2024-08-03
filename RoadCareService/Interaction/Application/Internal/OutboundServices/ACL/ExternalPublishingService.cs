using RoadCareService.Publishing.Interfaces.ACL;

namespace RoadCareService.Interaction.Application.Internal.OutboundServices.ACL
{
    internal class ExternalPublishingService
        (IPublishingContextFacade publishingContextFacade)
    {
        public async Task<bool> ExistsPublicationById
            (int id) => await publishingContextFacade
            .ExistsPublicationById(id);
    }
}