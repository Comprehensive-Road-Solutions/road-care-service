using RoadCareService.IAM.Domain.Model.Aggregates;
using RoadCareService.IAM.Domain.Model.Entities;
using RoadCareService.IAM.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.IAM.Infrastructure.Persistence.EFC.Repositories
{
    internal class CitizenCredentialRepository
        (RoadCareContext context) :
        BaseRepository<CitizenCredential>(context),
        ICitizenCredentialRepository
    {
        public async Task<string?> FindByCitizenIdAsync
            (int citizenId)
        {
            Task<CitizenCredential?> queryAsync = new(() =>
            {
                return
                (from cc in Context.Set<CitizenCredential>()
                join ci in Context.Set<Citizen>()
                on cc.CitizensId equals ci.Id
                where ci.Id == citizenId &&
                ci.State == "ACTIVO"
                select cc).FirstOrDefault();
            });

            queryAsync.Start();

            var result = await queryAsync;

            if (result is null)
                return null;

            return result.Code;
        }
    }
}