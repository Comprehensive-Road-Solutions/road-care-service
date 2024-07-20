using Microsoft.EntityFrameworkCore;
using RoadCareService.Monitoring.Domain.Model.Aggregates;
using RoadCareService.Monitoring.Domain.Model.ValueObjects.Staff;
using RoadCareService.Monitoring.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.Monitoring.Infrastructure.Persistence.EFC.Repositories
{
    public class StaffRepository(RoadCareContext context) :
        BaseRepository<Staff>(context), IStaffRepository
    {
        public async Task<bool> UpdateStaffStateAsync
            (int id, EStaffState staffState)
        {
            try
            {
                await Context.Set<Staff>().Where(s => s.Id == id)
                    .ExecuteUpdateAsync(s => s
                    .SetProperty(u => u.State, staffState.ToString()));

                return true;
            }
            catch (Exception) { return false; }
        }

        public async Task<IEnumerable<Staff>?> FindByStateAsync
            (EStaffState staffState) => await Context.Set<Staff>()
            .Where(s => s.State == staffState.ToString())
            .ToListAsync();

        public async Task<IEnumerable<Staff>?> FindByWorkerIdAsync
            (int workerId) => await Context.Set<Staff>()
            .Where(s => s.WorkersId == workerId)
            .ToListAsync();
    }
}