using RoadCareService.Interaction.Domain.Model.Aggregates;
using RoadCareService.Interaction.Domain.Model.Queries;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.Interaction.Domain.Repositories
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
        Task<IEnumerable<Comment>?> FindByPublicationsIdAsync
            (GetCommentsByPublicationsIdQuery query);
    }
}