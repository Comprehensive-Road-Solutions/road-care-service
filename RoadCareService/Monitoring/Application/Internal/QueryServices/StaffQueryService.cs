using RoadCareService.Monitoring.Domain.Model.Aggregates;
using RoadCareService.Monitoring.Domain.Model.Queries.Staff;
using RoadCareService.Monitoring.Domain.Repositories;
using RoadCareService.Monitoring.Domain.Services.Staff;

namespace RoadCareService.Monitoring.Application.Internal.QueryServices
{
    public class StaffQueryService
        (IStaffRepository staffRepository) :
        IStaffQueryService
    {
        public async Task<IEnumerable<Staff>?> Handle
            (GetAllStaffQuery query) =>
            await staffRepository.ListAsync();

        public async Task<Staff?> Handle
            (GetStaffByIdQuery query) =>
            await staffRepository.FindByIdAsync
            (query.Id);

        public async Task<IEnumerable<Staff>?> Handle
            (GetStaffByStateQuery query) =>
            await staffRepository.FindByStateAsync
            (query.StaffState);

        public async Task<IEnumerable<Staff>?> Handle
            (GetStaffByWorkerIdQuery query) =>
            await staffRepository.FindByWorkerIdAsync
            (query.WorkerId);
    }
}