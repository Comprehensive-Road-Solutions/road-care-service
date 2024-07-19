using RoadCareService.Assignment.Domain.Model.Aggregates;
using RoadCareService.Shared.Domain.Repositories;

namespace RoadCareService.Assignment.Domain.Repositories
{
    public interface IGovernmentEntityRepository :
        IBaseRepository<GovernmentEntity>
    { }
}