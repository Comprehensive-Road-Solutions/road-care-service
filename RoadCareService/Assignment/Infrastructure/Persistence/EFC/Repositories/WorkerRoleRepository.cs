using Microsoft.EntityFrameworkCore;
using RoadCareService.Assignment.Domain.Model.Aggregates;
using RoadCareService.Assignment.Domain.Model.Entities;
using RoadCareService.Assignment.Domain.Model.ValueObjects.WorkerRole;
using RoadCareService.Assignment.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.Assignment.Infrastructure.Persistence.EFC.Repositories
{
    public class WorkerRoleRepository(RoadCareContext context) :
        BaseRepository<WorkerRole>(context), IWorkerRoleRepository
    {
        public async Task<bool> UpdateWorkerRoleStateAsync
            (int id, EWorkerRoleState workerRoleState)
        {
            try
            {
                await Context.Set<WorkerRole>()
                    .Where(w => w.Id == id)
                    .ExecuteUpdateAsync(w => w
                    .SetProperty(u => u.State,
                    workerRoleState.ToString()));

                return true;
            }
            catch (Exception) { return true; }
        }

        public async Task<IEnumerable<WorkerRole>?> FindByGovernmentEntityIdAndWorkerAreaIdAsync
            (int governmentEntityId, int workerAreaId)
        {
            Task<IEnumerable<WorkerRole>?> queryAsync = new(() =>
            {
                return
                from wr in Context.Set<WorkerRole>().ToList()
                join wo in Context.Set<WorkerArea>().ToList()
                on wr.WorkersAreasId equals wo.Id
                join go in Context.Set<GovernmentEntity>().ToList()
                on wo.GovernmentsEntitiesId equals go.Id
                where go.Id == governmentEntityId &&
                wo.Id == workerAreaId
                select wr;
            });

            queryAsync.Start();

            return await queryAsync;
        }
    }
}