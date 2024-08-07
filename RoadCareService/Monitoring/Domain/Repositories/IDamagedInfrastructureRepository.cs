using RoadCareService.Monitoring.Domain.Model.Aggregates;
using RoadCareService.Monitoring.Domain.Model.ValueObjects.DamagedInfrastructure;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.Monitoring.Domain.Repositories
{
    public interface IDamagedInfrastructureRepository :
        IBaseRepository<DamagedInfrastructure>
    {
        Task<bool> AssignWorkDateToDamagedInfrastructureAsync
            (int id, DateTime workDate);

        Task<bool> UpdateDamagedInfrastructureStateAsync
            (int id, EDamagedInfrastructureState damagedInfrastructureState);

        Task<IEnumerable<DamagedInfrastructure>> FindByStateAsync
            (EDamagedInfrastructureState damagedInfrastructureState);

        Task<IEnumerable<DamagedInfrastructure>> FindByDepartmentIdAndDistrictIdAsync
            (int departmentId, int districtId);
    }
}