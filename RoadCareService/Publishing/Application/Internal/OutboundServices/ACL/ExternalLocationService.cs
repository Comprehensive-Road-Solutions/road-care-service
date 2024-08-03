using RoadCareService.Location.Interfaces.ACL;

namespace RoadCareService.Publishing.Application.Internal.OutboundServices.ACL
{
    internal class ExternalLocationService
        (ILocationContextFacade locationContextFacade)
    {
        public async Task<bool> ExistsDistrictById
            (int id) => await locationContextFacade
            .ExistsDistrictById(id);
    }
}