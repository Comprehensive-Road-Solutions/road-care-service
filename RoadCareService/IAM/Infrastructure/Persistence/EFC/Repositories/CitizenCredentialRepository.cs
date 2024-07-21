using RoadCareService.IAM.Domain.Model.Entities;
using RoadCareService.IAM.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.IAM.Infrastructure.Persistence.EFC.Repositories
{
    public class CitizenCredentialRepository
        (RoadCareContext context) :
        BaseRepository<CitizenCredential>(context),
        ICitizenCredentialRepository
    {
        public Task<string?> FindByCitizenId(int citizenId)
        {
            throw new NotImplementedException();
        }
    }
}