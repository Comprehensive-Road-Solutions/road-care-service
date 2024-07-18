using RoadCareService.Monitoring.Domain.Model.Aggregates;
using RoadCareService.Monitoring.Domain.Model.ValueObjects.DamagedInfrastructure;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.Monitoring.Domain.Repositories
{
    public interface IDamagedInfrastructure : IBaseRepository<DamagedInfrastructure>
    {
        Task<IEnumerable<DamagedInfrastructure>?> FindByDepartmentsIdAndDistrictsIdAsync
            (int departmentsId, int districtsId);
        Task<IEnumerable<DamagedInfrastructure>?> FindByStateAsync
            (EDamagedInfrastructureState damagedInfrastructureState);
    }
}