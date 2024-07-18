using Dapper;
using System.Data;
using RoadCareService.Monitoring.Domain.Model.Aggregates;
using RoadCareService.Monitoring.Domain.Model.ValueObjects.Staff;
using RoadCareService.Monitoring.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.Monitoring.Infrastructure.Persistence.Dapper.Repositories
{
    public class StaffRepositoryDapper(IDbConnection connection) :
        BaseRepository<Staff>(null), IStaffRepository
    {
        public async Task<IEnumerable<Staff>?> FindByStateAsync
            (EStaffState staffState)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@state", staffState.ToString());

            return await connection.QueryAsync<Staff>("", parameters,
                commandType: CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<Staff>?> FindByWorkersIdAsync
            (int workersId)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@workers_id", workersId);

            return await connection.QueryAsync<Staff>("", parameters,
                commandType: CommandType.StoredProcedure);
        }
    }
}