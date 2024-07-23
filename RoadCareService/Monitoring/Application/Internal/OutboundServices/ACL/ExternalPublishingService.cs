using RoadCareService.Publishing.Interfaces.ACL;

namespace RoadCareService.Monitoring.Application.Internal.OutboundServices.ACL
{
    public class ExternalPublishingService
        (IPublishingContextFacade publishingContextFacade)
    {
        public async Task<bool> ExistsDistrictById
            (int id) => await publishingContextFacade
            .ExistsDistrictById(id);
    }
}