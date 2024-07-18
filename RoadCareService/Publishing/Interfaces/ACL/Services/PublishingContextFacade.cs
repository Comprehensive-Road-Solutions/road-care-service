using RoadCareService.Publishing.Domain.Model.Entities;
using RoadCareService.Publishing.Domain.Model.Queries.District;
using RoadCareService.Publishing.Domain.Model.Queries.Publication;
using RoadCareService.Publishing.Domain.Services.District;
using RoadCareService.Publishing.Domain.Services.Publication;

namespace RoadCareService.Publishing.Interfaces.ACL.Services
{
    public class PublishingContextFacade(IDistrictQueryService districtQueryService,
        IPublicationQueryService publicationQueryService) : IPublishingContextFacade
    {
        public async Task<IEnumerable<District>?> ExistsDistrictByDepartmentsId
            (int departmentsId) => await districtQueryService
            .Handle(new GetDistrictsByDepartmentsIdQuery(departmentsId));
        public async Task<bool> ExistsPublicationById(int id)
        {
            var result = await publicationQueryService
                .Handle(new GetPublicationByIdQuery(id));

            if (result is null)
                return false;

            return true;
        }
    }
}