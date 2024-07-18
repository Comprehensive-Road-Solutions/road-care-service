using Dapper;
using System.Data;
using System.Text.RegularExpressions;
using RoadCareService.Monitoring.Domain.Model.Aggregates;
using RoadCareService.Monitoring.Domain.Model.ValueObjects.DamagedInfrastructure;
using RoadCareService.Monitoring.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.Monitoring.Infrastructure.Persistence.Dapper.Repositories
{
    public class DamagedInfrastructureRepositoryDapper(IDbConnection connection) :
        BaseRepository<DamagedInfrastructure>(null), IDamagedInfrastructureRepository
    {
        public async Task<IEnumerable<DamagedInfrastructure>?> FindByDepartmentsIdAndDistrictsIdAsync
            (int departmentsId, int districtsId)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@departments_id", departmentsId);
            parameters.Add("@districts_id", districtsId);

            return await connection.QueryAsync<DamagedInfrastructure>("", parameters,
                commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<DamagedInfrastructure>?> FindByStateAsync
            (EDamagedInfrastructureState damagedInfrastructureState)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@state",
                Regex.Replace(damagedInfrastructureState
                .ToString(), "([A-Z])", " $1").Trim());

            return await connection.QueryAsync<DamagedInfrastructure>("", parameters,
                commandType: CommandType.StoredProcedure);
        }
    }
}