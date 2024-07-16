using Dapper;
using System.Data;
using RoadCareService.Interaction.Domain.Model.Aggregates;
using RoadCareService.Interaction.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.Interaction.Infrastructure.Persistence.Dapper.Repositories
{
    public class CommentRepositoryDapper(IDbConnection connection) :
        BaseRepository<Comment>(null), ICommentRepository
    {
        public async Task<IEnumerable<Comment>?> FindByPublicationsIdAsync
            (int publicationsId)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@publications_id", publicationsId);

            var result = await connection.QueryAsync<Comment>
                ("sp_search_comments_by_publications_id", parameters,
                commandType: CommandType.StoredProcedure);

            return result;
        }
    }
}