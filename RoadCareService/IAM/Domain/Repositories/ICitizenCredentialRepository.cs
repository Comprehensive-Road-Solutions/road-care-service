using RoadCareService.IAM.Domain.Model.Entities;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.IAM.Domain.Repositories
{
    public interface ICitizenCredentialRepository :
        IBaseRepository<CitizenCredential>
    {
        Task<string?> FindByCitizenId
            (int citizenId);
    }
}