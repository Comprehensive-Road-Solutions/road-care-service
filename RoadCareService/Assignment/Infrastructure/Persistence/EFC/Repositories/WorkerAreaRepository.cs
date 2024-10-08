﻿using Microsoft.EntityFrameworkCore;
using RoadCareService.Assignment.Domain.Model.Aggregates;
using RoadCareService.Assignment.Domain.Model.Entities;
using RoadCareService.Assignment.Domain.Model.ValueObjects.WorkerArea;
using RoadCareService.Assignment.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.Assignment.Infrastructure.Persistence.EFC.Repositories
{
    internal class WorkerAreaRepository
        (RoadCareContext context,
        IHttpContextAccessor httpContextAccessor) :
        BaseRepository<WorkerArea>(context),
        IWorkerAreaRepository
    {
        public async Task<bool> UpdateWorkerAreaStateAsync
            (int id, EWorkerAreaState workerAreaState)
        {
            try
            {
                Task<WorkerArea?> queryAsync = new(() =>
                {
                    if (httpContextAccessor.HttpContext is null)
                        return null;

                    var credentials = httpContextAccessor.HttpContext
                        .Items["Credentials"] as dynamic;

                    if (credentials is null)
                        return null;

                    return
                    (from wa in Context.Set<WorkerArea>().ToList()
                    join ge in Context.Set<GovernmentEntity>().ToList()
                    on wa.GovernmentsEntitiesId equals ge.Id
                    where wa.Id == id &&
                    wa.Name == credentials.WorkerAreaName &&
                    ge.DistrictsId == credentials.DistrictId
                    select wa).FirstOrDefault();
                });

                queryAsync.Start();

                if (await queryAsync is null)
                    return false;

                return await Context.Set<WorkerArea>().Where(w => w.Id == id)
                    .ExecuteUpdateAsync(w => w
                    .SetProperty(u => u.State, workerAreaState.ToString())) > 0;
            }
            catch (Exception) { return false; }
        }

        public new async Task<IEnumerable<WorkerArea>> ListAsync()
        {
            Task<IEnumerable<WorkerArea>> queryAsync = new(() =>
            {
                if (httpContextAccessor.HttpContext is null)
                    return [];

                var credentials = httpContextAccessor.HttpContext
                    .Items["Credentials"] as dynamic;

                if (credentials is null)
                    return [];

                return
                (from wa in Context.Set<WorkerArea>().ToList()
                join ge in Context.Set<GovernmentEntity>().ToList()
                on wa.GovernmentsEntitiesId equals ge.Id
                where ge.DistrictsId == credentials.DistrictId
                select wa).ToList();
            });

            queryAsync.Start();

            return await queryAsync;
        }

        public new async Task<WorkerArea?> FindByIdAsync
            (int id)
        {
            Task<WorkerArea?> queryAsync = new(() =>
            {
                if (httpContextAccessor.HttpContext is null)
                    return null;

                var credentials = httpContextAccessor.HttpContext
                    .Items["Credentials"] as dynamic;

                if (credentials is null)
                    return null;

                return
                (from wa in Context.Set<WorkerArea>().ToList()
                join ge in Context.Set<GovernmentEntity>().ToList()
                on wa.GovernmentsEntitiesId equals ge.Id
                where wa.Id == id &&
                ge.DistrictsId == credentials.DistrictId
                select wa).FirstOrDefault();
            });

            queryAsync.Start();

            return await queryAsync;
        }

        public async Task<IEnumerable<WorkerArea>> FindByGovernmentEntityIdAsync
            (int governmentEntityId)
        {
            Task<IEnumerable<WorkerArea>> queryAsync = new(() =>
            {
                if (httpContextAccessor.HttpContext is null)
                    return [];

                var credentials = httpContextAccessor.HttpContext
                    .Items["Credentials"] as dynamic;

                if (credentials is null)
                    return [];

                return
                (from wa in Context.Set<WorkerArea>().ToList()
                join ge in Context.Set<GovernmentEntity>().ToList()
                on wa.GovernmentsEntitiesId equals ge.Id
                where ge.Id == governmentEntityId &&
                ge.DistrictsId == credentials.DistrictId
                select wa).ToList();
            });

            queryAsync.Start();

            return await queryAsync;
        }

        public async Task<IEnumerable<WorkerArea>> FindByGovernmentEntityIdAndStateAsync
            (int governmentEntityId, EWorkerAreaState workerAreaState)
        {
            Task<IEnumerable<WorkerArea>> queryAsync = new(() =>
            {
                if (httpContextAccessor.HttpContext is null)
                    return [];

                var credentials = httpContextAccessor.HttpContext
                    .Items["Credentials"] as dynamic;

                if (credentials is null)
                    return [];

                return
                (from wa in Context.Set<WorkerArea>().ToList()
                join ge in Context.Set<GovernmentEntity>().ToList()
                on wa.GovernmentsEntitiesId equals ge.Id
                where wa.State == workerAreaState.ToString() &&
                ge.Id == governmentEntityId &&
                ge.DistrictsId == credentials.DistrictId
                select wa).ToList();
            });

            queryAsync.Start();

            return await queryAsync;
        }
    }
}