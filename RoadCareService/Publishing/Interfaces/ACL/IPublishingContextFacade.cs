using RoadCareService.Publishing.Domain.Model.Aggregates;

namespace RoadCareService.Publishing.Interfaces.ACL
{
    public interface IPublishingContextFacade
    {
        Task<IEnumerable<Publication>?> GetAllPublications();

        Task<IEnumerable<Evidence>?> GetEvidencesByPublicationId
            (int publicationId);

        Task<bool> ExistsPublicationById
            (int id);
    }
}