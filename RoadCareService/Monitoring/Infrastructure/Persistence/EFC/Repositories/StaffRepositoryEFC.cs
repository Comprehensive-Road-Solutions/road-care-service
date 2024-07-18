using RoadCareService.Monitoring.Domain.Model.Aggregates;
using RoadCareService.Monitoring.Domain.Model.ValueObjects.Staff;
using RoadCareService.Monitoring.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.Monitoring.Infrastructure.Persistence.EFC.Repositories
{
    public class StaffRepositoryEFC(RoadCareContext context) :
        BaseRepository<Staff>(context), IStaffRepository
    {
        public Task<IEnumerable<Staff>?> FindByStateAsync
            (EStaffState staffState) =>
            throw new NotSupportedException("This search is done by dapper!");
        public Task<IEnumerable<Staff>?> FindByWorkersIdAsync
            (int workersId) =>
            throw new NotSupportedException("This search is done by dapper!");
    }
}