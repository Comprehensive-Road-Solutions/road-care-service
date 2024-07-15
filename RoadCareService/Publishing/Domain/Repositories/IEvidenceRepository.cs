using RoadCareService.Publishing.Domain.Model.Aggregates;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.Publishing.Domain.Repositories
{
    public interface IEvidenceRepository : IBaseRepository<Evidence>
    {
        Task<IEnumerable<Evidence>> FindByPublicationsIdAsync
            (int publicationsId);
    }
}