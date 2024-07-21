using Microsoft.EntityFrameworkCore;
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
        public async Task<string?> FindByWorkerIdAsync
            (int workerId)
        {
            var result = await Context
                .Set<WorkerCredential>()
                .Where(w => w.WorkersId == workerId)
                .FirstOrDefaultAsync();

            if (result is null)
                return null;

            return result.Code;
        }
    }
}