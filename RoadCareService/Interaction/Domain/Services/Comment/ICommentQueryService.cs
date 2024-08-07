using RoadCareService.Interaction.Domain.Model.Queries.Comment;

namespace RoadCareService.Interaction.Domain.Services.Comment
{
    public interface ICommentQueryService
    {
        Task<IEnumerable<Model.Aggregates.Comment>> Handle
            (GetCommentsByPublicationIdQuery query);
    }
}