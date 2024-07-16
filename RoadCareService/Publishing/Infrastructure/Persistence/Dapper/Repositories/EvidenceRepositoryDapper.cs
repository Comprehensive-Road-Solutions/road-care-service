using Dapper;
using System.Data;
using RoadCareService.Publishing.Domain.Model.Aggregates;
using RoadCareService.Publishing.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.Publishing.Infrastructure.Persistence.Dapper.Repositories
{
    public class EvidenceRepositoryDapper(RoadCareContext context, IDbConnection connection) :
        BaseRepository<Evidence>(context), IEvidenceRepository
    {
        public async Task<IEnumerable<Evidence>?> FindByPublicationsIdAsync
            (int publicationsId)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@publications_id", publicationsId);

            var result = await connection.QueryAsync<Evidence>
                ("sp_search_evidences_by_publications_id",
                parameters, commandType: CommandType.StoredProcedure);

            return result;
        }
    }
}