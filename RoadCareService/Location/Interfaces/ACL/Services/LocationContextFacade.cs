using RoadCareService.Location.Domain.Model.Queries.District;
using RoadCareService.Location.Domain.Services.District;

namespace RoadCareService.Location.Interfaces.ACL.Services
{
    public class LocationContextFacade
        (IDistrictQueryService districtQueryService) :
        ILocationContextFacade
    {
        public async Task<bool> ExistsDistrictById
            (int id) => await districtQueryService
            .Handle(new GetDistrictByIdQuery(id));
    }
}