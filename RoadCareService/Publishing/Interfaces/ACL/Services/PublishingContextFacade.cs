using RoadCareService.Publishing.Domain.Model.Queries.Publication;
using RoadCareService.Publishing.Domain.Services.Publication;

namespace RoadCareService.Publishing.Interfaces.ACL.Services
{
    internal class PublishingContextFacade
        (IPublicationQueryService publicationQueryService) :
        IPublishingContextFacade
    {
        public async Task<bool> ExistsPublicationById
            (int id) => await publicationQueryService
            .Handle(new GetPublicationByIdQuery
                (id)) != null;
    }
}