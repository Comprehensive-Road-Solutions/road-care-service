using Microsoft.EntityFrameworkCore;
using RoadCareService.Publishing.Domain.Model.Aggregates;
using RoadCareService.Publishing.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.Publishing.Infrastructure.Persistence.EFC.Repositories
{
    public class EvidenceRepository(RoadCareContext context) :
        BaseRepository<Evidence>(context), IEvidenceRepository
    {
        public async Task<IEnumerable<Evidence>?> FindByPublicationsIdAsync
            (int publicationsId) => await Context.Set<Evidence>()
            .Where(e => e.PublicationsId == publicationsId).ToListAsync();
    }
}