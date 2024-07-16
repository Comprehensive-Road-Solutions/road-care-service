using RoadCareService.Publishing.Domain.Model.Aggregates;
using RoadCareService.Publishing.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.Publishing.Infrastructure.Persistence.EFC.Repositories
{
    public class EvidenceRepositoryEFC(RoadCareContext context) :
        BaseRepository<Evidence>(context), IEvidenceRepository
    {
        public Task<IEnumerable<Evidence>?> FindByPublicationsIdAsync
            (int publicationsId) => throw new NotSupportedException
            ("This search is done by dapper!");
    }
}