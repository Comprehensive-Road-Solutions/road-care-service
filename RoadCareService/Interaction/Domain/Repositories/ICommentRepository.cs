using RoadCareService.Interaction.Domain.Model.Aggregates;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.Interaction.Domain.Repositories
{
    public interface ICommentRepository :
        IBaseRepository<Comment>
    {
        Task<IEnumerable<Comment>> FindByPublicationIdAsync
            (int publicationId);
    }
}