using RoadCareService.Monitoring.Domain.Model.Aggregates;
using RoadCareService.Monitoring.Domain.Model.ValueObjects.DamagedInfrastructure;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.Monitoring.Domain.Repositories
{
    public interface IDamagedInfrastructureRepository :
        IBaseRepository<DamagedInfrastructure>
    {
        Task<bool> UpdateDamagedInfrastructureStateAsync
            (int id, EDamagedInfrastructureState damagedInfrastructureState);
        Task<bool> AssignWorkDateToDamagedInfrastructureAsync
            (int id, DateTime workDate);
        Task<IEnumerable<DamagedInfrastructure>?> FindByDepartmentsIdAndDistrictsIdAsync
            (int departmentsId, int districtsId);
        Task<IEnumerable<DamagedInfrastructure>?> FindByStateAsync
            (EDamagedInfrastructureState damagedInfrastructureState);
    }
}