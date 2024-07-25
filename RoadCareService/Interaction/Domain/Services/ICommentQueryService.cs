using RoadCareService.Interaction.Domain.Model.Aggregates;
using RoadCareService.Interaction.Domain.Model.Queries;

namespace RoadCareService.Interaction.Domain.Services
{
    public interface ICommentQueryService
    {
        Task<IEnumerable<Comment>> Handle
            (GetCommentsByPublicationIdQuery query);
    }
}