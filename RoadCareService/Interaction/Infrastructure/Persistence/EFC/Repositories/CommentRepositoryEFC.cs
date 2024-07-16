using RoadCareService.Interaction.Domain.Model.Aggregates;
using RoadCareService.Interaction.Domain.Model.Queries;
using RoadCareService.Interaction.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.Interaction.Infrastructure.Persistence.EFC.Repositories
{
    public partial class CommentRepositoryEFC(RoadCareContext context) :
        BaseRepository<Comment>(context), ICommentRepository
    {
        public Task<IEnumerable<Comment>?> FindByPublicationsIdAsync
            (GetCommentsByPublicationsIdQuery query) =>
            throw new NotSupportedException("");
    }
}