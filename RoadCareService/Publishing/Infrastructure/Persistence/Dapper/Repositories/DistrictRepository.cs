using Dapper;
using System.Data;
using RoadCareService.Publishing.Domain.Model.Entities;
using RoadCareService.Publishing.Domain.Repositories;

namespace RoadCareService.Publishing.Infrastructure.Persistence.Dapper.Repositories
{
    public class DistrictRepository(IDbConnection connection) : IDistrictRepository
    {
        public async Task<IEnumerable<District>?> FindByDepartmentsIdAsync(int departmentsId)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@departments_id", departmentsId);

            var result = await connection.QueryAsync<District>
                ("sp_search_districts_by_department_id", parameters,
                commandType: CommandType.StoredProcedure);

            return result;
        }
    }
}