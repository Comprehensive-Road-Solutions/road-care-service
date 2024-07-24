using RoadCareService.IAM.Domain.Model.Entities;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.IAM.Domain.Repositories
{
    public interface IWorkerCredentialRepository :
        IBaseRepository<WorkerCredential>
    {
        Task<dynamic?> FindByWorkerIdAsync
            (int workerId);
    }
}