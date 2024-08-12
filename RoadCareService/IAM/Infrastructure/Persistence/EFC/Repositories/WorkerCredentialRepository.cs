using RoadCareService.Assignment.Domain.Model.Aggregates;
using RoadCareService.Assignment.Domain.Model.Entities;
using RoadCareService.IAM.Domain.Model.Aggregates;
using RoadCareService.IAM.Domain.Model.Entities;
using RoadCareService.IAM.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.IAM.Infrastructure.Persistence.EFC.Repositories
{
    internal class WorkerCredentialRepository
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
                (from wc in Context.Set<WorkerCredential>()
                 join wo in Context.Set<Worker>()
                 on wc.WorkersId equals wo.Id
                 join aw in Context.Set<AssignmentWorker>()
                 on wo.Id equals aw.WorkersId
                 join wr in Context.Set<WorkerRole>()
                 on aw.WorkersRolesId equals wr.Id
                 join wa in Context.Set<WorkerArea>()
                 on wr.WorkersAreasId equals wa.Id
                 join ge in Context.Set<GovernmentEntity>()
                 on wa.GovernmentsEntitiesId equals ge.Id
                 where wo.Id == workerId &&
                 wo.State == "ACTIVO" &&
                 aw.State == "VIGENTE" &&
                 wr.State == "ACTIVO" &&
                 wa.State == "ACTIVO"
                 select new
                 {
                     WorkerCredentialCode = wc.Code,
                     DistrictId = ge.DistrictsId.ToString(),
                     WorkerAreaName = wa.Name
                 })
                 .FirstOrDefault();
            });

            queryAsync.Start();

            return await queryAsync;
        }
    }
}