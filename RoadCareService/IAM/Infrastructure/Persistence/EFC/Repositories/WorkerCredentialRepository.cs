using RoadCareService.IAM.Domain.Model.Entities;
using RoadCareService.IAM.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.IAM.Infrastructure.Persistence.EFC.Repositories
{
    public class WorkerCredentialRepository
        (RoadCareContext context) :
        BaseRepository<WorkerCredential>(context),
        IWorkerCredentialRepository
    {
        public Task<string?> FindByWorkerId(int workerId)
        {
            throw new NotImplementedException();
        }
    }
}