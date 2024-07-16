using Dapper;
using System.Data;
using RoadCareService.Publishing.Domain.Model.Aggregates;
using RoadCareService.Publishing.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.Publishing.Infrastructure.Persistence.Dapper.Repositories
{
    public class PublicationRepositoryDapper(RoadCareContext context, IDbConnection connection) :
        BaseRepository<Publication>(context), IPublicationRepository
    {
        public async Task<IEnumerable<Publication>?> FindByDepartmentsIdAndDistrictsIdAsync
            (int departmentsId, int districtsId)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@departments_id", departmentsId);
            parameters.Add("@districts_id", departmentsId);

            var result = await connection.QueryAsync<Publication>
                ("sp_search_publication_by_departments_id_and_districts_id",
                parameters, commandType: CommandType.StoredProcedure);

            return result;
        }
    }
}