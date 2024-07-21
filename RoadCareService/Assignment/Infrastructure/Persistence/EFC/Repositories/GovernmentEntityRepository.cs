using RoadCareService.Assignment.Domain.Model.Aggregates;
using RoadCareService.Assignment.Domain.Repositories;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Configuration;
using RoadCareService.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace RoadCareService.Assignment.Infrastructure.Persistence.EFC.Repositories
{
    public class GovernmentEntityRepository
        (RoadCareContext context) :
        BaseRepository<GovernmentEntity>(context),
        IGovernmentEntityRepository
    { }
}