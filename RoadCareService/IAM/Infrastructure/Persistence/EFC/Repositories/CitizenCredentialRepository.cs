using Microsoft.EntityFrameworkCore;
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
        public async Task<string?> FindByCitizenIdAsync
            (int citizenId)
        {
            var result = await Context
                .Set<CitizenCredential>()
                .Where(c => c.CitizensId == citizenId)
                .FirstOrDefaultAsync();

            if (result is null)
                return null;

            return result.Code;
        }
    }
}