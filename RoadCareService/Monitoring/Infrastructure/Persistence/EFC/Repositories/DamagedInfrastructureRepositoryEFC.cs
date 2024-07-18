using RoadCareService.Monitoring.Domain.Model.Aggregates;
using RoadCareService.Monitoring.Domain.Model.ValueObjects.DamagedInfrastructure;
using RoadCareService.Monitoring.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.Monitoring.Infrastructure.Persistence.EFC.Repositories
{
    public class DamagedInfrastructureRepositoryEFC(RoadCareContext context) :
        BaseRepository<DamagedInfrastructure>(context), IDamagedInfrastructureRepository
    {
        public Task<IEnumerable<DamagedInfrastructure>?> FindByDepartmentsIdAndDistrictsIdAsync
            (int departmentsId, int districtsId) =>
            throw new NotSupportedException("This search is done by dapper!");
        public Task<IEnumerable<DamagedInfrastructure>?> FindByStateAsync
            (EDamagedInfrastructureState damagedInfrastructureState) =>
            throw new NotSupportedException("This search is done by dapper!");

    }
}