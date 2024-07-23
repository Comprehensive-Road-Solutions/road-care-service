using RoadCareService.Publishing.Interfaces.ACL;

namespace RoadCareService.IAM.Application.Internal.OutboundServices.ACL
{
    public class ExternalPublishingService
        (IPublishingContextFacade publishingContextFacade)
    {
        public async Task<bool> ExistsDistrictById
            (int id) => await publishingContextFacade
            .ExistsDistrictById(id);
    }
}