using RoadCareService.Interaction.Domain.Model.Aggregates;
using RoadCareService.Interaction.Domain.Model.Queries.Comment;
using RoadCareService.Interaction.Domain.Repositories;
using RoadCareService.Interaction.Domain.Services.Comment;

namespace RoadCareService.Interaction.Application.Internal.QueryServices
{
    internal class CommentQueryService
        (ICommentRepository commentRepository) :
        ICommentQueryService
    {
        public async Task<IEnumerable<Comment>> Handle
            (GetCommentsByPublicationIdQuery query) =>
            await commentRepository.FindByPublicationIdAsync
            (query.PublicationId);
    }
}