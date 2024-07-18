using RoadCareService.Monitoring.Domain.Model.Aggregates;
using RoadCareService.Monitoring.Domain.Model.ValueObjects.Staff;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.Monitoring.Domain.Repositories
{
    public interface IStaffRepository : IBaseRepository<Staff>
    {
        Task<IEnumerable<Staff>> FindByStateAsync(EStaffState staffState);
        Task<IEnumerable<Staff>> FindByWorkersIdAsync(int workersId);
    }
}