using RoadCareService.Assignment.Domain.Model.Aggregates;
using RoadCareService.Assignment.Domain.Model.Entities;
using RoadCareService.IAM.Domain.Model.Aggregates;
using RoadCareService.IAM.Domain.Model.ValueObjects.Worker;
using RoadCareService.IAM.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.IAM.Infrastructure.Persistence.EFC.Repositories
{
    internal class WorkerRepository
        (RoadCareContext context,
        IHttpContextAccessor httpContextAccessor) :
        BaseRepository<Worker>(context),
        IWorkerRepository
    {
        public new async Task<Worker?> FindByIdAsync(int id)
        {
            Task<Worker?> queryAsync = new(() =>
            {
                if (httpContextAccessor.HttpContext is null)
                    return null;

                var credentials = httpContextAccessor.HttpContext
                    .Items["Credentials"] as dynamic;

                if (credentials is null)
                    return null;

                return
                (from wo in Context.Set<Worker>().ToList()
                join aw in Context.Set<AssignmentWorker>().ToList()
                on wo.Id equals aw.WorkersId
                join wr in Context.Set<WorkerRole>().ToList()
                on aw.WorkersRolesId equals wr.Id
                join wa in Context.Set<WorkerArea>().ToList()
                on wr.WorkersAreasId equals wa.Id
                join ge in Context.Set<GovernmentEntity>().ToList()
                on wa.GovernmentsEntitiesId equals ge.Id
                where wo.Id == id &&
                wo.State == EWorkerState.ACTIVO.ToString() &&
                aw.State == "VIGENTE" &&
                wr.State == "ACTIVO" &&
                wa.State == "ACTIVO" &&
                ge.DistrictsId == credentials.DistrictId
                select wo).FirstOrDefault();
            });

            queryAsync.Start();

            return await queryAsync;
        }
    }
}