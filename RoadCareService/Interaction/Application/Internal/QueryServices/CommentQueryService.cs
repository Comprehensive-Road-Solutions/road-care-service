using RoadCareService.Interaction.Domain.Model.Aggregates;
using RoadCareService.Interaction.Domain.Model.Queries;
using RoadCareService.Interaction.Domain.Repositories;
using RoadCareService.Interaction.Domain.Services;

namespace RoadCareService.Interaction.Application.Internal.QueryServices
{
    public class CommentQueryService(ICommentRepository commentRepository) :
        ICommentQueryService
    {
        public async Task<IEnumerable<Comment>?> Handle
            (GetCommentsByPublicationsIdQuery query) =>
            await commentRepository.FindByPublicationsIdAsync
            (query.PublicationsId);
    }
}