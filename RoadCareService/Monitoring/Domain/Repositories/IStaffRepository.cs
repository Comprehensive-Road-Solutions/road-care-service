using RoadCareService.Monitoring.Domain.Model.Aggregates;
using RoadCareService.Monitoring.Domain.Model.ValueObjects.Staff;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.Monitoring.Domain.Repositories
{
    public interface IStaffRepository :
        IBaseRepository<Staff>
    {
        Task<bool> UpdateStaffStateAsync
            (int id, EStaffState staffState);

        Task<IEnumerable<Staff>> FindByWorkerIdAsync
            (int workerId);

        Task<IEnumerable<Staff>> FindByStateAsync
            (EStaffState staffState);
    }
}