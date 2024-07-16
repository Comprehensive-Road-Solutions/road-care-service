using RoadCareService.Interaction.Domain.Model.Aggregates;
using RoadCareService.Interaction.Domain.Model.Queries;
using RoadCareService.Interaction.Domain.Repositories;
using RoadCareService.Interaction.Domain.Services;
using RoadCareService.Interaction.Infrastructure.Persistence.Dapper.Repositories;
using System.Data;

namespace RoadCareService.Interaction.Application.Internal.QueryServices
{
    public class CommentQueryService(IDbConnection connection) :
        ICommentQueryService
    {
        private readonly ICommentRepository CommentRepository =
            new CommentRepositoryDapper(connection);

        public async Task<IEnumerable<Comment>?> Handle
            (GetCommentsByPublicationsIdQuery query) =>
            await CommentRepository
            .FindByPublicationsIdAsync(query.PublicationsId);
    }
}