using Microsoft.EntityFrameworkCore;
using RoadCareService.Assignment.Domain.Model.Aggregates;
using RoadCareService.Assignment.Domain.Model.Entities;
using RoadCareService.IAM.Domain.Model.Aggregates;
using RoadCareService.Monitoring.Domain.Model.Aggregates;
using RoadCareService.Monitoring.Domain.Model.ValueObjects.Staff;
using RoadCareService.Monitoring.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.Monitoring.Infrastructure.Persistence.EFC.Repositories
{
    internal class StaffRepository
        (RoadCareContext context,
        IHttpContextAccessor httpContextAccessor) :
        BaseRepository<Staff>(context),
        IStaffRepository
    {
        public async Task<bool> UpdateStaffStateAsync
            (int id, EStaffState staffState)
        {
            try
            {
                Task<Staff?> queryAsync = new(() =>
                {
                    if (httpContextAccessor.HttpContext is null)
                        return null;

                    var credentials = httpContextAccessor.HttpContext
                        .Items["Credentials"] as dynamic;

                    if (credentials is null)
                        return null;

                    return
                    (from st in Context.Set<Staff>().ToList()
                     join wo in Context.Set<Worker>().ToList()
                     on st.WorkersId equals wo.Id
                     join aw in Context.Set<AssignmentWorker>().ToList()
                     on wo.Id equals aw.WorkersId
                     join wr in Context.Set<WorkerRole>().ToList()
                     on aw.WorkersRolesId equals wr.Id
                     join wa in Context.Set<WorkerArea>().ToList()
                     on wr.WorkersAreasId equals wa.Id
                     join ge in Context.Set<GovernmentEntity>().ToList()
                     on wa.GovernmentsEntitiesId equals ge.Id
                     where st.Id == id &&
                     wo.State == "ACTIVO" &&
                     aw.State == "VIGENTE" &&
                     wr.State == "ACTIVO" &&
                     wa.State == "ACTIVO" &&
                     ge.DistrictsId == credentials.DistrictId
                     select st)
                     .FirstOrDefault();
                });

                queryAsync.Start();

                if (await queryAsync is null)
                    return false;

                return await Context.Set<Staff>().Where(s => s.Id == id)
                    .ExecuteUpdateAsync(s => s
                    .SetProperty(u => u.State, staffState.ToString())) > 0;
            }
            catch (Exception) { return false; }
        }

        public async Task<IEnumerable<Staff>> FindByWorkerIdAsync
            (int workerId)
        {
            Task<IEnumerable<Staff>> queryAsync = new(() =>
            {
                if (httpContextAccessor.HttpContext is null)
                    return [];

                var credentials = httpContextAccessor.HttpContext
                    .Items["Credentials"] as dynamic;

                if (credentials is null)
                    return [];

                return
                (from st in Context.Set<Staff>().ToList()
                 join wo in Context.Set<Worker>().ToList()
                 on st.WorkersId equals wo.Id
                 join aw in Context.Set<AssignmentWorker>().ToList()
                 on wo.Id equals aw.WorkersId
                 join wr in Context.Set<WorkerRole>().ToList()
                 on aw.WorkersRolesId equals wr.Id
                 join wa in Context.Set<WorkerArea>().ToList()
                 on wr.WorkersAreasId equals wa.Id
                 join ge in Context.Set<GovernmentEntity>().ToList()
                 on wa.GovernmentsEntitiesId equals ge.Id
                 where wo.Id == workerId &&
                 wo.State == "ACTIVO" &&
                 aw.State == "VIGENTE" &&
                 wr.State == "ACTIVO" &&
                 wa.State == "ACTIVO" &&
                 ge.DistrictsId == credentials.DistrictId
                 select st).ToList();
            });

            queryAsync.Start();

            return await queryAsync;
        }

        public async Task<IEnumerable<Staff>> FindByStateAsync
            (EStaffState staffState)
        {
            Task<IEnumerable<Staff>> queryAsync = new(() =>
            {
                if (httpContextAccessor.HttpContext is null)
                    return [];

                var credentials = httpContextAccessor.HttpContext
                    .Items["Credentials"] as dynamic;

                if (credentials is null)
                    return [];

                return
                (from st in Context.Set<Staff>().ToList()
                 join wo in Context.Set<Worker>().ToList()
                 on st.WorkersId equals wo.Id
                 join aw in Context.Set<AssignmentWorker>().ToList()
                 on wo.Id equals aw.WorkersId
                 join wr in Context.Set<WorkerRole>().ToList()
                 on aw.WorkersRolesId equals wr.Id
                 join wa in Context.Set<WorkerArea>().ToList()
                 on wr.WorkersAreasId equals wa.Id
                 join ge in Context.Set<GovernmentEntity>().ToList()
                 on wa.GovernmentsEntitiesId equals ge.Id
                 where st.State == staffState.ToString() &&
                 wo.State == "ACTIVO" &&
                 aw.State == "VIGENTE" &&
                 wr.State == "ACTIVO" &&
                 wa.State == "ACTIVO" &&
                 ge.DistrictsId == credentials.DistrictId
                 select st).ToList();
            });

            queryAsync.Start();

            return await queryAsync;
        }
    }
}