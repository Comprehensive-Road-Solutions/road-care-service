﻿using Microsoft.EntityFrameworkCore;
using RoadCareService.Assignment.Domain.Model.Aggregates;
using RoadCareService.Assignment.Domain.Model.Entities;
using RoadCareService.Assignment.Domain.Model.ValueObjects.AssignmentWorker;
using RoadCareService.Assignment.Domain.Repositories;
using RoadCareService.Location.Domain.Model.Aggregates;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.Assignment.Infrastructure.Persistence.EFC.Repositories
{
    internal class AssignmentWorkerRepository
        (RoadCareContext context,
        IHttpContextAccessor httpContextAccessor) :
        BaseRepository<AssignmentWorker>(context),
        IAssignmentWorkerRepository
    {
        public async Task<bool> UpdateAssignmentWorkerStateAsync
            (int id, EAssignmentWorkerState assignmentWorkerState)
        {
            try
            {
                Task<AssignmentWorker?> queryAsync = new(() =>
                {
                    if (httpContextAccessor.HttpContext is null)
                        return null;

                    var credentials = httpContextAccessor.HttpContext
                        .Items["Credentials"] as dynamic;

                    if (credentials is null)
                        return null;

                    return
                    (from aw in Context.Set<AssignmentWorker>().ToList()
                    join wr in Context.Set<WorkerRole>().ToList()
                    on aw.WorkersRolesId equals wr.Id
                    join wo in Context.Set<WorkerArea>().ToList()
                    on wr.WorkersAreasId equals wo.Id
                    join go in Context.Set<GovernmentEntity>().ToList()
                    on wo.GovernmentsEntitiesId equals go.Id
                    join di in Context.Set<District>().ToList()
                    on go.DistrictsId equals di.Id
                    where aw.Id == id &&
                    wo.Name == credentials.WorkerAreaName &&
                    di.Id == credentials.DistrictId
                    select aw)
                    .FirstOrDefault();
                });

                queryAsync.Start();

                if (await queryAsync is null)
                    return false;

                await Context.Set<AssignmentWorker>().Where(a => a.Id == id)
                    .ExecuteUpdateAsync(a => a
                    .SetProperty(u => u.State, assignmentWorkerState.ToString()));

                return true;
            }
            catch (Exception) { return false; }
        }

        public new async Task<IEnumerable<AssignmentWorker>> ListAsync()
        {
            Task<IEnumerable<AssignmentWorker>> queryAsync = new(() =>
            {
                if (httpContextAccessor.HttpContext is null)
                    return [];

                var credentials = httpContextAccessor.HttpContext
                    .Items["Credentials"] as dynamic;

                if (credentials is null)
                    return [];

                return
                (from aw in Context.Set<AssignmentWorker>().ToList()
                 join wr in Context.Set<WorkerRole>().ToList()
                 on aw.WorkersRolesId equals wr.Id
                 join wo in Context.Set<WorkerArea>().ToList()
                 on wr.WorkersAreasId equals wo.Id
                 join go in Context.Set<GovernmentEntity>().ToList()
                 on wo.GovernmentsEntitiesId equals go.Id
                 join di in Context.Set<District>().ToList()
                 on go.DistrictsId equals di.Id
                 where di.Id == credentials.DistrictId
                 select aw).ToList();
            });

            queryAsync.Start();

            return await queryAsync;
        }

        public new async Task<AssignmentWorker?> FindByIdAsync
            (int id)
        {
            Task<AssignmentWorker?> queryAsync = new(() =>
            {
                if (httpContextAccessor.HttpContext is null)
                    return null;

                var credentials = httpContextAccessor.HttpContext
                    .Items["Credentials"] as dynamic;

                if (credentials is null)
                    return null;

                return
                (from aw in Context.Set<AssignmentWorker>().ToList()
                 join wr in Context.Set<WorkerRole>().ToList()
                 on aw.WorkersRolesId equals wr.Id
                 join wo in Context.Set<WorkerArea>().ToList()
                 on wr.WorkersAreasId equals wo.Id
                 join go in Context.Set<GovernmentEntity>().ToList()
                 on wo.GovernmentsEntitiesId equals go.Id
                 join di in Context.Set<District>().ToList()
                 on go.DistrictsId equals di.Id
                 where aw.Id == id &&
                 di.Id == credentials.DistrictId
                 select aw)
                 .FirstOrDefault();
            });

            queryAsync.Start();

            return await queryAsync;
        }

        public async Task<IEnumerable<AssignmentWorker>> FindByGovernmentEntityIdAndWorkerAreaIdAsync
            (int governmentEntityId, int workerAreaId)
        {
            Task<IEnumerable<AssignmentWorker>> queryAsync = new(() =>
            {
                if (httpContextAccessor.HttpContext is null)
                    return [];

                var credentials = httpContextAccessor.HttpContext
                    .Items["Credentials"] as dynamic;

                if (credentials is null)
                    return [];

                return
                (from aw in Context.Set<AssignmentWorker>().ToList()
                 join wr in Context.Set<WorkerRole>().ToList()
                 on aw.WorkersRolesId equals wr.Id
                 join wo in Context.Set<WorkerArea>().ToList()
                 on wr.WorkersAreasId equals wo.Id
                 join go in Context.Set<GovernmentEntity>().ToList()
                 on wo.GovernmentsEntitiesId equals go.Id
                 join di in Context.Set<District>().ToList()
                 on go.DistrictsId equals di.Id
                 where wo.Id == workerAreaId &&
                 go.Id == governmentEntityId &&
                 di.Id == credentials.DistrictId
                 select aw).ToList();
            });

            queryAsync.Start();

            return await queryAsync;
        }

        public async Task<IEnumerable<AssignmentWorker>> FindByGovernmentEntityIdAndWorkerAreaIdAndRoleIdAsync
            (int governmentEntityId, int workerAreaId, int roleId)
        {
            Task<IEnumerable<AssignmentWorker>> queryAsync = new(() =>
            {
                if (httpContextAccessor.HttpContext is null)
                    return [];

                var credentials = httpContextAccessor.HttpContext
                    .Items["Credentials"] as dynamic;

                if (credentials is null)
                    return [];

                return
                (from aw in Context.Set<AssignmentWorker>().ToList()
                join wr in Context.Set<WorkerRole>().ToList()
                on aw.WorkersRolesId equals wr.Id
                join wo in Context.Set<WorkerArea>().ToList()
                on wr.WorkersAreasId equals wo.Id
                join go in Context.Set<GovernmentEntity>().ToList()
                on wo.GovernmentsEntitiesId equals go.Id
                join di in Context.Set<District>().ToList()
                on go.DistrictsId equals di.Id
                where wr.Id == roleId &&
                wo.Id == workerAreaId &&
                go.Id == governmentEntityId &&
                di.Id == credentials.DistrictId
                select aw).ToList();
            });

            queryAsync.Start();

            return await queryAsync;
        }
    }
}