using Microsoft.EntityFrameworkCore;
using RoadCareService.Assignment.Domain.Model.Entities;
using RoadCareService.Assignment.Domain.Model.ValueObjects.WorkerArea;
using RoadCareService.Assignment.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.Assignment.Infrastructure.Persistence.EFC.Repositories
{
    public class WorkerAreaRepository
        (RoadCareContext context) :
        BaseRepository<WorkerArea>(context),
        IWorkerAreaRepository
    {
        public async Task<bool> UpdateWorkerAreaStateAsync
            (int id, EWorkerAreaState workerAreaState)
        {
            try
            {
                await Context.Set<WorkerArea>().Where(w => w.Id == id)
                    .ExecuteUpdateAsync(w => w
                    .SetProperty(u => u.State, workerAreaState.ToString()));

                return true;
            }
            catch (Exception) { return false; }
        }

        public async Task<IEnumerable<WorkerArea>?> FindByGovernmentEntityIdAndStateAsync
            (int governmentEntityId, EWorkerAreaState workerAreaState) =>
            await Context.Set<WorkerArea>().Where
            (w => w.GovernmentsEntitiesId == governmentEntityId &&
            w.State == workerAreaState.ToString()).ToListAsync();

        public async Task<IEnumerable<WorkerArea>?> FindByGovernmentEntityIdAsync
            (int governmentEntityId) =>
            await Context.Set<WorkerArea>().Where
            (w => w.GovernmentsEntitiesId == governmentEntityId).ToListAsync();
    }
}