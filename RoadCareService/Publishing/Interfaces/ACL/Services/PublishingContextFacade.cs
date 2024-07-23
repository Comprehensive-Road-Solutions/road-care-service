using RoadCareService.Publishing.Domain.Model.Aggregates;
using RoadCareService.Publishing.Domain.Model.Queries.District;
using RoadCareService.Publishing.Domain.Model.Queries.Evidence;
using RoadCareService.Publishing.Domain.Model.Queries.Publication;
using RoadCareService.Publishing.Domain.Services.District;
using RoadCareService.Publishing.Domain.Services.Evidence;
using RoadCareService.Publishing.Domain.Services.Publication;

namespace RoadCareService.Publishing.Interfaces.ACL.Services
{
    public class PublishingContextFacade
        (IDistrictQueryService districtQueryService,
        IPublicationQueryService publicationQueryService,
        IEvidenceQueryService evidenceQueryService) :
        IPublishingContextFacade
    {
        public async Task<IEnumerable<Publication>?> GetAllPublications() =>
            await publicationQueryService
            .Handle(new GetAllPublicationsQuery());

        public async Task<IEnumerable<Evidence>?> GetEvidencesByPublicationId
            (int publicationId) => await evidenceQueryService
            .Handle(new GetEvidencesByPublicationIdQuery
                (publicationId));

        public async Task<bool> ExistsDistrictById
            (int id) => await districtQueryService
            .Handle(new GetDistrictByIdQuery(id));

        public async Task<bool> ExistsPublicationById
            (int id)
        {
            var result = await publicationQueryService
                .Handle(new GetPublicationByIdQuery(id));

            if (result is null)
                return false;

            return true;
        }
    }
}