using Microsoft.EntityFrameworkCore;
using RoadCareService.Assignment.Domain.Model.Aggregates;
using RoadCareService.Assignment.Domain.Model.Entities;
using RoadCareService.Assignment.Domain.Model.ValueObjects.WorkerRole;
using RoadCareService.Assignment.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.Assignment.Infrastructure.Persistence.EFC.Repositories
{
    internal class WorkerRoleRepository
        (RoadCareContext context,
        IHttpContextAccessor httpContextAccessor) :
        BaseRepository<WorkerRole>(context),
        IWorkerRoleRepository
    {
        public async Task<bool> UpdateWorkerRoleStateAsync
            (int id, EWorkerRoleState workerRoleState)
        {
            try
            {
                Task<WorkerRole?> queryAsync = new(() =>
                {
                    if (httpContextAccessor.HttpContext is null)
                        return null;

                    var credentials = httpContextAccessor.HttpContext
                        .Items["Credentials"] as dynamic;

                    if (credentials is null)
                        return null;

                    return
                    (from wr in Context.Set<WorkerRole>().ToList()
                    join wa in Context.Set<WorkerArea>().ToList()
                    on wr.WorkersAreasId equals wa.Id
                    join ge in Context.Set<GovernmentEntity>().ToList()
                    on wa.GovernmentsEntitiesId equals ge.Id
                    where wr.Id == id &&
                    ge.DistrictsId == credentials.DistrictId
                    select wr).FirstOrDefault();
                });

                queryAsync.Start();

                if (await queryAsync is null)
                    return false;

                return await Context.Set<WorkerRole>()
                    .Where(w => w.Id == id)
                    .ExecuteUpdateAsync(w => w
                    .SetProperty(u => u.State, workerRoleState.ToString())) > 0;
            }
            catch (Exception) { return true; }
        }

        public new async Task<IEnumerable<WorkerRole>> ListAsync()
        {
            Task<IEnumerable<WorkerRole>> queryAsync = new(() =>
            {
                if (httpContextAccessor.HttpContext is null)
                    return [];

                var credentials = httpContextAccessor.HttpContext
                    .Items["Credentials"] as dynamic;

                if (credentials is null)
                    return [];

                return
                (from wr in Context.Set<WorkerRole>().ToList()
                join wa in Context.Set<WorkerArea>().ToList()
                on wr.WorkersAreasId equals wa.Id
                join ge in Context.Set<GovernmentEntity>().ToList()
                on wa.GovernmentsEntitiesId equals ge.Id
                where ge.DistrictsId == credentials.DistrictId
                select wr).ToList();
            });

            queryAsync.Start();

            return await queryAsync;
        }

        public new async Task<WorkerRole?> FindByIdAsync
            (int id)
        {
            Task<WorkerRole?> queryAsync = new(() =>
            {
                if (httpContextAccessor.HttpContext is null)
                    return null;

                var credentials = httpContextAccessor.HttpContext
                    .Items["Credentials"] as dynamic;

                if (credentials is null)
                    return null;

                return
                (from wr in Context.Set<WorkerRole>().ToList()
                join wa in Context.Set<WorkerArea>().ToList()
                on wr.WorkersAreasId equals wa.Id
                join ge in Context.Set<GovernmentEntity>().ToList()
                on wa.GovernmentsEntitiesId equals ge.Id
                where wr.Id == id &&
                ge.DistrictsId == credentials.DistrictId
                select wr).FirstOrDefault();
            });

            queryAsync.Start();

            return await queryAsync;
        }

        public async Task<IEnumerable<WorkerRole>> FindByGovernmentEntityIdAndWorkerAreaIdAsync
            (int governmentEntityId, int workerAreaId)
        {
            Task<IEnumerable<WorkerRole>> queryAsync = new(() =>
            {
                if (httpContextAccessor.HttpContext is null)
                    return [];

                var credentials = httpContextAccessor.HttpContext
                    .Items["Credentials"] as dynamic;

                if (credentials is null)
                    return [];

                return
                (from wr in Context.Set<WorkerRole>().ToList()
                join wa in Context.Set<WorkerArea>().ToList()
                on wr.WorkersAreasId equals wa.Id
                join ge in Context.Set<GovernmentEntity>().ToList()
                on wa.GovernmentsEntitiesId equals ge.Id
                where wa.Id == workerAreaId &&
                ge.Id == governmentEntityId &&
                ge.DistrictsId == credentials.DistrictId
                select wr).ToList();
            });

            queryAsync.Start();

            return await queryAsync;
        }
    }
}