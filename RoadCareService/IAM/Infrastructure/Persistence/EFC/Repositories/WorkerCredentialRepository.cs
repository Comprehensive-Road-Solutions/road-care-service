using RoadCareService.Assignment.Domain.Model.Aggregates;
using RoadCareService.Assignment.Domain.Model.Entities;
using RoadCareService.IAM.Domain.Model.Aggregates;
using RoadCareService.IAM.Domain.Model.Entities;
using RoadCareService.IAM.Domain.Repositories;
using RoadCareService.Location.Domain.Model.Aggregates;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.IAM.Infrastructure.Persistence.EFC.Repositories
{
    public class WorkerCredentialRepository
        (RoadCareContext context) :
        BaseRepository<WorkerCredential>(context),
        IWorkerCredentialRepository
    {
        public async Task<dynamic?> FindByWorkerIdAsync
            (int workerId)
        {
            Task<dynamic?> queryAsync = new(() =>
            {
                return
                (from wc in Context.Set<WorkerCredential>().ToList()
                 join wo in Context.Set<Worker>().ToList()
                 on wc.WorkersId equals wo.Id
                 join aw in Context.Set<AssignmentWorker>().ToList()
                 on wo.Id equals aw.WorkersId
                 join wr in Context.Set<WorkerRole>().ToList()
                 on aw.WorkersRolesId equals wr.Id
                 join wa in Context.Set<WorkerArea>().ToList()
                 on wr.WorkersAreasId equals wa.Id
                 join go in Context.Set<GovernmentEntity>().ToList()
                 on wa.GovernmentsEntitiesId equals go.Id
                 join di in Context.Set<District>().ToList()
                 on go.DistrictsId equals di.Id
                 where wo.Id == workerId &&
                 wo.State == "ACTIVO" &&
                 aw.State == "VIGENTE" &&
                 wr.State == "ACTIVO" &&
                 wa.State == "ACTIVO"
                 select new
                 {
                     WorkerCredentialCode = wc.Code,
                     DistrictId = di.Id.ToString(),
                     WorkerAreaName = wa.Name
                 })
                 .FirstOrDefault();
            });

            queryAsync.Start();

            return await queryAsync;
        }
    }
}