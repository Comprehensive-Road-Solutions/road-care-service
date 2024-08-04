using RoadCareService.Publishing.Domain.Model.Aggregates;
using RoadCareService.Publishing.Domain.Model.Queries.Evidence;
using RoadCareService.Publishing.Domain.Model.Queries.Publication;
using RoadCareService.Publishing.Domain.Services.Evidence;
using RoadCareService.Publishing.Domain.Services.Publication;

namespace RoadCareService.Publishing.Interfaces.ACL.Services
{
    internal class PublishingContextFacade
        (IPublicationQueryService publicationQueryService,
        IEvidenceQueryService evidenceQueryService) :
        IPublishingContextFacade
    {
        public async Task<IEnumerable<Publication>?> GetAllPublications() =>
            await publicationQueryService
            .Handle(new GetAllPublicationsQuery());

        public async Task<bool> ExistsPublicationById
            (int id) => await publicationQueryService
            .Handle(new GetPublicationByIdQuery
                (id)) != null;

        public async Task<IEnumerable<Evidence>?> GetEvidencesByPublicationId
            (int publicationId) => await evidenceQueryService
            .Handle(new GetEvidencesByPublicationIdQuery
                (publicationId));
    }
}