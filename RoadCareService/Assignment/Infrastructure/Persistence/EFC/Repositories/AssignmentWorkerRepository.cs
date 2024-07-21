using Microsoft.EntityFrameworkCore;
using RoadCareService.Assignment.Domain.Model.Aggregates;
using RoadCareService.Assignment.Domain.Model.Entities;
using RoadCareService.Assignment.Domain.Model.ValueObjects.AssignmentWorker;
using RoadCareService.Assignment.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.Assignment.Infrastructure.Persistence.EFC.Repositories
{
    public class AssignmentWorkerRepository
        (RoadCareContext context) :
        BaseRepository<AssignmentWorker>(context),
        IAssignmentWorkerRepository
    {
        public async Task<bool> UpdateAssignmentWorkerStateAsync
            (int id, EAssignmentWorkerState assignmentWorkerState)
        {
            try
            {
                await Context.Set<AssignmentWorker>().Where(a => a.Id == id)
                    .ExecuteUpdateAsync(a => a
                    .SetProperty(u => u.State, assignmentWorkerState.ToString()));

                return true;
            }
            catch (Exception) { return false; }
        }

        public async Task<IEnumerable<AssignmentWorker>?> FindByGovernmentEntityIdAndWorkerAreaIdAndRoleIdAsync
            (int governmentEntityId, int workerAreaId, int roleId)
        {
            Task<IEnumerable<AssignmentWorker>?> queryAsync = new(() =>
            {
                return
                from aw in Context.Set<AssignmentWorker>().ToList()
                join wr in Context.Set<WorkerRole>().ToList()
                on aw.WorkersRolesId equals wr.Id
                join wo in Context.Set<WorkerArea>().ToList()
                on wr.WorkersAreasId equals wo.Id
                join go in Context.Set<GovernmentEntity>().ToList()
                on wo.GovernmentsEntitiesId equals go.Id
                where aw.WorkersRolesId == roleId &&
                wo.Id == workerAreaId &&
                go.Id == governmentEntityId
                select aw;
            });

            queryAsync.Start();

            return await queryAsync;
        }

        public async Task<IEnumerable<AssignmentWorker>?> FindByGovernmentEntityIdAndWorkerAreaIdAsync
            (int governmentEntityId, int workerAreaId)
        {
            Task<IEnumerable<AssignmentWorker>?> queryAsync = new(() =>
            {
                return
                from aw in Context.Set<AssignmentWorker>().ToList()
                join wr in Context.Set<WorkerRole>().ToList()
                on aw.WorkersRolesId equals wr.Id
                join wo in Context.Set<WorkerArea>().ToList()
                on wr.WorkersAreasId equals wo.Id
                join go in Context.Set<GovernmentEntity>().ToList()
                on wo.GovernmentsEntitiesId equals go.Id
                where wo.Id == workerAreaId &&
                go.Id == governmentEntityId
                select aw;
            });

            queryAsync.Start();

            return await queryAsync;
        }
    }
}