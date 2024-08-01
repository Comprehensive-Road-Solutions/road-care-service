using RoadCareService.IAM.Domain.Model.Aggregates;
using RoadCareService.IAM.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.IAM.Infrastructure.Persistence.EFC.Repositories
{
    internal class CitizenRepository
        (RoadCareContext context) :
        BaseRepository<Citizen>(context),
        ICitizenRepository
    { }
}