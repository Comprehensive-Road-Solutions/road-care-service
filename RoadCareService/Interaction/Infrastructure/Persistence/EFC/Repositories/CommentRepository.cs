using Microsoft.EntityFrameworkCore;
using RoadCareService.Interaction.Domain.Model.Aggregates;
using RoadCareService.Interaction.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.Interaction.Infrastructure.Persistence.EFC.Repositories
{
    public class CommentRepository(RoadCareContext context) :
        BaseRepository<Comment>(context), ICommentRepository
    {
        public async Task<IEnumerable<Comment>?> FindByPublicationsIdAsync
            (int publicationsId) =>
            await Context.Set<Comment>().Where
            (c => c.PublicationsId == publicationsId).ToListAsync();
    }
}